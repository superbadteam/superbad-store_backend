namespace ShoppingManagement.Core.Application.Users.DTOs;

public class ProductTypeCartDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public ProductCartDto Product { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }
}