namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class ProductTypeCartDto
{
    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public ProductCartDto Product { get; set; } = null!;
}