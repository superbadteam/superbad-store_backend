using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.Entities;

public sealed class User : AggregateRoot
{
    public User()
    {
        AverageRating = 0;
        ProductSold = 0;
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

    public double AverageRating { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverUrl { get; set; }

    public int ProductSold { get; set; }

    public ICollection<Product> Products { get; set; } = null!;
}