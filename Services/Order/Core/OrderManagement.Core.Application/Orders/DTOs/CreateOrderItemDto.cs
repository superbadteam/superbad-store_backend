namespace OrderManagement.Core.Application.Orders.DTOs;

public class CreateOrderItemDto
{
    public Guid ProductTypeId { get; set; }

    public int Quantity { get; set; }
}