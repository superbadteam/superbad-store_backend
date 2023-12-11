namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class AddToCartDto
{
    public Guid ProductTypeId { get; set; }
    public int Quantity { get; set; }
}