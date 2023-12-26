using OrderManagement.Core.Application.Users.DTOs;

namespace OrderManagement.Core.Application.Orders.DTOs;

public class OrderDetailDto
{
    public Guid Id { get; set; }

    public ShippingAddressDto ShippingAddress { get; set; } = null!;

    public IEnumerable<OrderItemDto> Items { get; set; } = null!;

    public double TotalPrice { get; set; }
}