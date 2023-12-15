using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Entities;

public class Order : AggregateRoot
{
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }

    public Order(Guid userId, Guid shippingAddressId, List<OrderItem> orderItems) : this()
    {
        UserId = userId;
        ShippingAddressId = shippingAddressId;
        OrderItems = orderItems;
        TotalPrice = orderItems.Sum(x => x.TotalPrice);
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid ShippingAddressId { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = null!;

    public List<OrderItem> OrderItems { get; set; }

    public double TotalPrice { get; set; }
}