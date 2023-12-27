namespace OrderManagement.Core.Application.Users.DTOs;

public class ShippingAddressDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public bool IsMainAddress { get; set; }
}