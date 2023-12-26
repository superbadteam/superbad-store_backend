namespace SaleManagement.Core.Application.Products.DTOs;

public class ProductTypeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }
}