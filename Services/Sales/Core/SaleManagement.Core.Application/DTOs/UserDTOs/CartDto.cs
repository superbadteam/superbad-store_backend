namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class CartDto
{
    public IEnumerable<CartItemDto> Items { get; set; } = null!;

    public double TotalPrice { get; set; }
}