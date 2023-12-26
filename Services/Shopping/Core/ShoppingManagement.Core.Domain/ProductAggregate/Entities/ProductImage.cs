using BuildingBlock.Core.Domain;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Entities;

public sealed class ProductImage : Entity
{
    public ProductImage()
    {
    }

    public ProductImage(Guid id, string url, DateTime createdAt, string createdBy)
    {
        Id = id;
        Url = url;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public string Url { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;
}