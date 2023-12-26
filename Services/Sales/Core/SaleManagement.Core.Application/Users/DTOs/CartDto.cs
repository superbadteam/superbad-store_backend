namespace SaleManagement.Core.Application.Users.DTOs;

public class CartDto
{
    public IEnumerable<CartItemDto> Items { get; set; } = null!;

    public double TotalPrice { get; set; }
}