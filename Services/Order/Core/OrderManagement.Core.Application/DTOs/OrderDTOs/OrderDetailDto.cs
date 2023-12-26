using OrderManagement.Core.Application.DTOs.UserDTOs;

namespace OrderManagement.Core.Application.DTOs.OrderDTOs;

public class OrderDetailDto
{
    public Guid Id { get; set; }

    public ShippingAddressDto ShippingAddress { get; set; } = null!;

    public IEnumerable<OrderItemDto> Items { get; set; } = null!;

    public double TotalPrice { get; set; }
}