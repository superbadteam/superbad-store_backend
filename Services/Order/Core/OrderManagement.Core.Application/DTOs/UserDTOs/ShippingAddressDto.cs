namespace OrderManagement.Core.Application.DTOs.UserDTOs;

public class ShippingAddressDto
{
    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;
}