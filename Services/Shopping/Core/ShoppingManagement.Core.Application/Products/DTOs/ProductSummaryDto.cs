namespace ShoppingManagement.Core.Application.Products.DTOs;

public class ProductSummaryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double MinPrice { get; set; }

    public double MaxPrice { get; set; }

    public int Sold { get; set; }

    public double Rating { get; set; }

    public string ImageUrl { get; set; } = null!;
}