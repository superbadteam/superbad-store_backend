using BuildingBlock.Core.Domain;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities.Enums;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Entities;

public sealed class Product : AggregateRoot
{
    public Product()
    {
        Sold = 0;
        Rating = 0;
        TotalReviews = 0;
        MinPrice = 0;
        MaxPrice = 0;
        Types = new List<ProductType>();
        Images = new List<ProductImage>();
    }

    public Product(Guid id, Guid userId, string name, string description,
        Guid categoryId, ProductCondition condition, DateTime createdAt, string createdBy) : this()
    {
        Id = id;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Condition = condition;
        UserId = userId;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public List<ProductType> Types { get; set; }

    public int Sold { get; set; }

    public double Rating { get; set; }

    public int TotalReviews { get; set; }

    public ProductCondition Condition { get; set; }

    public double MinPrice { get; set; }

    public double MaxPrice { get; set; }

    public List<ProductImage> Images { get; set; }

    public ProductType AddTypes(Guid id, string name, int quantity, double price, string? imageUrl, DateTime createdAt,
        string createdBy)
    {
        var type = new ProductType(id, name, quantity, price, imageUrl, createdAt, createdBy);

        Types.Add(type);

        return type;
    }

    public void SetPriceRange(double minPrice, double maxPrice)
    {
        MinPrice = minPrice;
        MaxPrice = maxPrice;
    }

    public void AddImage(Guid id, string url, DateTime createdAt, string createdBy)
    {
        var image = new ProductImage(id, url, createdAt, createdBy);

        Images.Add(image);
    }

    public void UpdateRating(double rating, int totalReviews)
    {
        Rating = rating;
        TotalReviews = totalReviews;
    }
}