namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class CartItemDto
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public ProductTypeCartDto ProductType { get; set; } = null!;
}