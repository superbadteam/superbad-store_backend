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

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;
}