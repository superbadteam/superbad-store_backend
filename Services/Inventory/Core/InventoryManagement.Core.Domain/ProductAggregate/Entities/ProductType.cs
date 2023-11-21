using BuildingBlock.Core.Domain;

namespace InventoryManagement.Core.Domain.ProductAggregate.Entities;

public class ProductType : Entity
{
    public ProductType()
    {
        Images = new List<ProductImage>();
    }

    public ProductType(string name, int quantity, double price) : this()
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public List<ProductImage> Images { get; set; }

    public void AddImage(string url)
    {
        var image = new ProductImage(url);

        Images.Add(image);
    }
}