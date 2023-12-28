using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Application.Orders.CQRS.Commands.Requests;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Application.Orders.DTOs.Enums;
using OrderManagement.Core.Application.Orders.IntegrationEvents.Events;
using OrderManagement.Core.Application.Users.IntegrationEvents.Events;
using OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Exceptions;

namespace OrderManagement.Core.Application.Orders.CQRS.Commands.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDetailDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IOrderDomainService _orderDomainService;
    private readonly IOperationRepository<Order> _orderOperationRepository;
    private readonly IReadOnlyRepository<Order> _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IOperationRepository<Order> orderOperationRepository,
        IOrderDomainService orderDomainService, IUnitOfWork unitOfWork, ICurrentUser currentUser,
        IReadOnlyRepository<Order> readOnlyRepository, IEventBus eventBus, IMapper mapper)
    {
        _orderOperationRepository = orderOperationRepository;
        _orderDomainService = orderDomainService;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _readOnlyRepository = readOnlyRepository;
        _eventBus = eventBus;
        _mapper = mapper;
    }

    public async Task<OrderDetailDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderItems = await CreateOrderItemsAsync(request.Dto, request.Method);

        var order = await _orderDomainService.CreateAsync(_currentUser.Id, request.Dto.ShippingAddressId, orderItems,
            request.Dto.CartItemIds);

        await _orderOperationRepository.AddAsync(order);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new OrderCreatedIntegrationEvent(_mapper.Map<IEnumerable<OrderItemPayload>>(orderItems),
            _currentUser.Id));

        if (request.Method == AddItemMethod.TakeFromCart)
            _eventBus.Publish(new CartItemsRemovedIntegrationEvent(_currentUser.Id, request.Dto.CartItemIds!));

        return Optional<OrderDetailDto>
            .Of(await _readOnlyRepository.GetAnyAsync<OrderDetailDto>(new EntityIdSpecification<Order>(order.Id)))
            .ThrowIfNotExist(new OrderNotFoundException(order.Id)).Get();
    }

    private async Task<List<OrderItem>> CreateOrderItemsAsync(CreateOrderDto dto, AddItemMethod method)
    {
        var orderItems = new List<OrderItem>();

        if (method == AddItemMethod.Direct)
            foreach (var orderItemDto in dto.OrderItems!)
            {
                var orderItem =
                    await _orderDomainService.CreateItemAsync(orderItemDto.ProductTypeId, orderItemDto.Quantity);

                orderItems.Add(orderItem);
            }
        else
            foreach (var cartItemId in dto.CartItemIds!)
            {
                var orderItem = await _orderDomainService.CreateItemAsync(_currentUser.Id, cartItemId);

                orderItems.Add(orderItem);
            }

        return orderItems;
    }
}