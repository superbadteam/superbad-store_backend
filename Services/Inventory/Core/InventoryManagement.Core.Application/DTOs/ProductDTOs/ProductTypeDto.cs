namespace InventoryManagement.Core.Application.DTOs.ProductDTOs;

public class ProductTypeDto
{
    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public List<ProductImageDto> Images { get; set; } = null!;
}