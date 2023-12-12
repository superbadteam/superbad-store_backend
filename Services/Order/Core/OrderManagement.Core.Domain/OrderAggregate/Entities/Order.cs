using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Entities;

public class Order : AggregateRoot
{
    public Guid UserId { get; set; }
    
    public User User { get; set; } = null!;

    public Guid ShippingAddressId { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = null!;
    
    public List<OrderItem> OrderItems { get; set; } = null!;
    
    public double TotalPrice { get; set; }
}