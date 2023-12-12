using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.ProductAggregate.Entities.Enums;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.ProductAggregate.Entities;

public sealed class Product : AggregateRoot
{
    public Product()
    {
        Types = new List<ProductType>();
    }

    public Product(Guid id, Guid userId, string name, ProductCondition condition, string image, DateTime createdAt,
        string createdBy) : this()
    {
        Id = id;
        Name = name;
        Condition = condition;
        UserId = userId;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        Image = image;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;

    public List<ProductType> Types { get; set; }

    public ProductCondition Condition { get; set; }

    public string Image { get; set; } = null!;

    public ProductType AddTypes(Guid id, string name, int quantity, double price, DateTime createdAt,
        string createdBy)
    {
        var type = new ProductType(id, name, quantity, price, createdAt, createdBy);

        Types.Add(type);

        return type;
    }
}