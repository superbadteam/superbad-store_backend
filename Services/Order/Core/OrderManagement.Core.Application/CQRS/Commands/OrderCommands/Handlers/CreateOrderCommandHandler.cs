using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;
using OrderManagement.Core.Application.DTOs.OrderDTOs;
using OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Exceptions;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDetailDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IOperationRepository<Order> _operationRepository;
    private readonly IOrderDomainService _orderDomainService;
    private readonly IReadOnlyRepository<Order> _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;


    public CreateOrderCommandHandler(IOperationRepository<Order> operationRepository,
        IOrderDomainService orderDomainService, IUnitOfWork unitOfWork, ICurrentUser currentUser,
        IReadOnlyRepository<Order> readOnlyRepository)
    {
        _operationRepository = operationRepository;
        _orderDomainService = orderDomainService;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<OrderDetailDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderItems = new List<OrderItem>();

        foreach (var orderItemDto in request.Dto.OrderItems)
        {
            var orderItem =
                await _orderDomainService.CreateItemAsync(orderItemDto.ProductTypeId, orderItemDto.Quantity);

            orderItems.Add(orderItem);
        }

        var order = await _orderDomainService.CreateAsync(_currentUser.Id, request.Dto.ShippingAddressId, orderItems);

        await _operationRepository.AddAsync(order);

        await _unitOfWork.SaveChangesAsync();

        return Optional<OrderDetailDto>
            .Of(await _readOnlyRepository.GetAnyAsync<OrderDetailDto>(new EntityIdSpecification<Order>(order.Id)))
            .ThrowIfNotExist(new OrderNotFoundException(order.Id)).Get();
    }
}