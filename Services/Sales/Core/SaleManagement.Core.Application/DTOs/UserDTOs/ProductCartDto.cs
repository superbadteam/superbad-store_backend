namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class ProductCartDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
}