namespace OrderManagement.Core.Application.Orders.DTOs;

public class CreateOrderDto
{
    public Guid ShippingAddressId { get; set; }

    public IEnumerable<CreateOrderItemDto>? OrderItems { get; set; }

    public IEnumerable<Guid>? CartItemIds { get; set; }
}