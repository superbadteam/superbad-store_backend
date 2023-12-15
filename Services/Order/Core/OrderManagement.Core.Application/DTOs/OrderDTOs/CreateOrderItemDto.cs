namespace OrderManagement.Core.Application.DTOs.OrderDTOs;

public class CreateOrderItemDto
{
    public Guid ProductTypeId { get; set; }

    public int Quantity { get; set; }
}