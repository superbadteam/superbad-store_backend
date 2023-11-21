using BuildingBlock.Core.Domain;

namespace InventoryManagement.Core.Domain.ProductAggregate.Entities;

public class ProductImage : Entity
{
    public ProductImage()
    {
    }

    public ProductImage(string url)
    {
        Url = url;
    }

    public string Url { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;
}