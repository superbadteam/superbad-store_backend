using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;

public interface IOrderItemDomainService
{
    OrderItem Create(Guid orderItemId, Guid productTypeId, Guid userId, int quantity, double totalPrice,
        DateTime createdAt, string createdBy);
}