namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class ProductTypeCartDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ProductCartDto Product { get; set; } = null!;
}