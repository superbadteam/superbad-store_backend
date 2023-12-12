using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Entities;

public sealed class User : AggregateRoot
{
    public User()
    {
        ShippingAddresses = new List<ShippingAddress>();
        Orders = new List<Order>();
        Products = new List<Product>();
    }

    public User(DateTime createdAt, string createdBy) : this()
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public User(Guid id, string name, DateTime createdAt, string createdBy) : this(createdAt, createdBy)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; } = null!;

    public List<ShippingAddress> ShippingAddresses { get; set; }

    public List<Order> Orders { get; set; }

    public List<Product> Products { get; set; }
}