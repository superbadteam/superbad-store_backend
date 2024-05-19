using BuildingBlock.Core.Domain.DomainEvents;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainEvents.Events;

public record OrderItemCreatedDomainEvent(IEnumerable<OrderItem> Items, IEnumerable<Guid>? CartItemIds, Guid UserId)
    : IDomainEvent;