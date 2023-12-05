namespace InventoryManagement.Core.Application.DTOs.ProductDTOs;

public class ProductSummaryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Sold { get; set; }

    public string ImageUrl { get; set; } = null!;
}