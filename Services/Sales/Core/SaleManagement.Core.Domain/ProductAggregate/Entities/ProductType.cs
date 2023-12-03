using BuildingBlock.Core.Domain;

namespace SaleManagement.Core.Domain.ProductAggregate.Entities;

public class ProductType : Entity
{
    public ProductType()
    {
    }

    public ProductType(string name, int quantity, double price) : this()
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }
}