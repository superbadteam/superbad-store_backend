namespace InventoryManagement.Core.Application.DTOs.ProductDTOs;

public class ProductSummaryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }
}