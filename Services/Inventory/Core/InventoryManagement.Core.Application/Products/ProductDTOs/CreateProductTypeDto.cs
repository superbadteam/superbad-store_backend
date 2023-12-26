namespace InventoryManagement.Core.Application.Products.ProductDTOs;

public class CreateProductTypeDto
{
    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }
}