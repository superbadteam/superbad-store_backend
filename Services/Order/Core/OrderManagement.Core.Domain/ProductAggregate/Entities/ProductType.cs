using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.ProductAggregate.Entities;

public sealed class ProductType : Entity
{
    public ProductType()
    {
        OrderItems = new List<OrderItem>();
        Carts = new List<Cart>();
    }

    public ProductType(Guid id, string name, int quantity, double price, DateTime createdAt,
        string createdBy) : this()
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
    }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public List<OrderItem> OrderItems { get; set; }

    public List<Cart> Carts { get; set; }
}