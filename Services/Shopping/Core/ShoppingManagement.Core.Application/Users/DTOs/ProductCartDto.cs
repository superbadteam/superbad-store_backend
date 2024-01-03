namespace ShoppingManagement.Core.Application.Users.DTOs;

public class ProductCartDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public string? DeletedBy { get; set; }
}