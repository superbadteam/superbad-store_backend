using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.DomainServices.Abstractions;

public interface IOrderDomainService
{
    Task<OrderItem> CreateItemAsync(Guid productTypeId, int quantity);

    Task<OrderItem> CreateItemAsync(Guid userId, Guid cartItemId);

    Task<Order> CreateAsync(Guid userId, Guid shippingAddressId, List<OrderItem> orderItems,
        IEnumerable<Guid>? cartItemIds);
}