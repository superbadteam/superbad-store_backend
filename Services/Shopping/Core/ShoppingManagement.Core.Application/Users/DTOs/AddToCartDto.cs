namespace ShoppingManagement.Core.Application.Users.DTOs;

public class AddToCartDto
{
    public Guid ProductTypeId { get; set; }
    public int Quantity { get; set; }
}