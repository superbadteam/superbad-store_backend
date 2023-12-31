using ReviewManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.DomainServices.Implementations;

public class OrderItemDomainService : IOrderItemDomainService
{
    public OrderItem Create(Guid orderItemId, Guid productTypeId, Guid userId, int quantity, double totalPrice,
        DateTime createdAt, string createdBy)
    {
        return new OrderItem(orderItemId, productTypeId, userId, quantity, totalPrice, createdAt, createdBy);
    }
}