namespace OrderManagement.Core.Application.Users.DTOs;

public class CreateShippingAddressDto
{
    public string Name { get; set; } = null!;

    public PhoneNumberDto PhoneNumber { get; set; } = null!;
    
    public Guid DistrictId { get; set; }
    
    public string Address { get; set; } = null!;

    public bool IsMainAddress { get; set; }
}

