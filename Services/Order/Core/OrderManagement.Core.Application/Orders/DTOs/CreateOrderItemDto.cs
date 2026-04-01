namespace OrderManagement.Core.Application.Orders.DTOs;

public class CreateOrderItemDto
{
    public Guid ProductTypeId { get; set; }

    public string StringProductTypeId { get; set; } = null!;

    public int Quantity { get; set; }
}