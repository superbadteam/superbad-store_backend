namespace ShoppingManagement.Core.Application.Users.DTOs;

public class ProductTypeCartDto
{
    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public ProductCartDto Product { get; set; } = null!;
}