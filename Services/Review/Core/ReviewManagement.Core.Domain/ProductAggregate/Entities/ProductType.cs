using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ProductAggregate.Entities;

public sealed class ProductType : Entity
{
    public ProductType()
    {
        Reviews = new List<Review>();
        OrderItems = new List<OrderItem>();
    }

    public ProductType(Guid id, string name, double price, DateTime createdAt, string createdBy) : this()
    {
        Id = id;
        Name = name;
        Price = price;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
    }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public List<Review> Reviews { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}