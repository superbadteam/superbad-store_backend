using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.ProductAggregate.Entities;

public sealed class Product : AggregateRoot
{
    public Product()
    {
        Types = new List<ProductType>();
    }

    public Product(Guid id, Guid userId, string name, string imageUrl, DateTime createdAt, string createdBy) : this()
    {
        Id = id;
        UserId = userId;
        Name = name;
        ImageUrl = imageUrl;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public List<ProductType> Types { get; set; }
    public string ImageUrl { get; set; } = null!;

    public string Name { get; set; } = null!;

    public ProductType AddTypes(Guid id, string name, double price, DateTime createdAt, string createdBy)
    {
        var type = new ProductType(id, name, price, createdAt, createdBy);

        Types.Add(type);

        return type;
    }
}