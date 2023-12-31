using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using ReviewManagement.Core.Application.Orders.IntegrationEvents.Events;
using ReviewManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Application.Orders.IntegrationEvents.Handlers;

public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
{
    private readonly IOrderItemDomainService _orderItemDomainService;
    private readonly IOperationRepository<OrderItem> _orderItemOperationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreatedIntegrationEventHandler(IUnitOfWork unitOfWork, IOrderItemDomainService orderItemDomainService,
        IOperationRepository<OrderItem> orderItemOperationRepository)
    {
        _unitOfWork = unitOfWork;
        _orderItemDomainService = orderItemDomainService;
        _orderItemOperationRepository = orderItemOperationRepository;
    }

    public async Task HandleAsync(OrderCreatedIntegrationEvent @event)
    {
        foreach (var orderItemPayload in @event.Items)
        {
            var orderItem = _orderItemDomainService.Create(orderItemPayload.Id, orderItemPayload.ProductTypeId,
                @event.UserId, orderItemPayload.Quantity, orderItemPayload.TotalPrice, orderItemPayload.CreatedAt,
                orderItemPayload.CreatedBy);

            await _orderItemOperationRepository.AddAsync(orderItem);
        }

        await _unitOfWork.SaveChangesAsync();
    }
}