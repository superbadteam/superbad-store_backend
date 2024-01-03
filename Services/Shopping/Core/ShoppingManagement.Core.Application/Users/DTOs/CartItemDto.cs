namespace ShoppingManagement.Core.Application.Users.DTOs;

public class CartItemDto
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public ProductTypeCartDto ProductType { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }
}