using BuildingBlock.Core.Domain.DomainEvents;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainEvents;

public record OrderItemCreatedDomainEvent(IEnumerable<OrderItem> Items) : IDomainEvent;