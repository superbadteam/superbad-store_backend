namespace ShoppingManagement.Core.Application.Products.DTOs;

public class ProductImageDto
{
    public Guid Id { get; set; }

    public string Url { get; set; } = null!;
}