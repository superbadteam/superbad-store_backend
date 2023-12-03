using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Entities.Enums;
using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Core.Domain.ProductAggregate.Entities;

public class Product : AggregateRoot
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

    public Product(string name, string description, Guid categoryId, ProductCondition condition, Guid userId) : this()
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Condition = condition;
        UserId = userId;
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

    public ProductType AddTypes(string name, int quantity, double price)
    {
        var type = new ProductType(name, quantity, price);

        Types.Add(type);

        return type;
    }

    public void SetPriceRange(double minPrice, double maxPrice)
    {
        MinPrice = minPrice;
        MaxPrice = maxPrice;
    }

    public void AddImage(string url)
    {
        var image = new ProductImage(url);

        Images.Add(image);
    }
}