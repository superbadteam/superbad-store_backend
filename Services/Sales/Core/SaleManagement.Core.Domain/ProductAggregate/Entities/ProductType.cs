using BuildingBlock.Core.Domain;

namespace SaleManagement.Core.Domain.ProductAggregate.Entities;

public sealed class ProductType : Entity
{
    public ProductType()
    {
    }

    public ProductType(Guid id, string name, int quantity, double price, string? imageUrl, DateTime createdAt,
        string createdBy) : this()
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        ImageUrl = imageUrl;
    }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }
}