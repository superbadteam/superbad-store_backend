using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;

public interface IOrderDomainService
{
    Task<OrderItem> CreateItemAsync(Guid productTypeId, int quantity);

    Task<Order> CreateAsync(Guid userId, Guid shippingAddressId, List<OrderItem> orderItems);
}