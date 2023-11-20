using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;
using InventoryManagement.Core.Domain.UserAggregate.Entities;

namespace InventoryManagement.Core.Domain.ProductAggregate.Entities;

public class Product : AggregateRoot
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public ICollection<ProductType> Types { get; set; } = null!;

    public int Sold { get; set; }

    public ICollection<ProductImage> Images { get; set; } = null!;

    public double Rating { get; set; }

    public int TotalReviews { get; set; }

    public ProductCondition Condition { get; set; }
}