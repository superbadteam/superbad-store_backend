using BuildingBlock.Core.Domain;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace InventoryManagement.Core.Domain.ProductAggregate.Entities;

public class Product : AggregateRoot
{
    public Product()
    {
        Sold = 0;
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

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public List<ProductType> Types { get; set; }

    public int Sold { get; set; }

    public ProductCondition Condition { get; set; }

    public List<ProductImage> Images { get; set; }

    public ProductType AddTypes(string name, int quantity, double price, string? imageUrl)
    {
        var type = new ProductType(name, quantity, price, imageUrl);

        Types.Add(type);

        return type;
    }

    public void AddImage(string url)
    {
        var image = new ProductImage(url);

        Images.Add(image);
    }
}