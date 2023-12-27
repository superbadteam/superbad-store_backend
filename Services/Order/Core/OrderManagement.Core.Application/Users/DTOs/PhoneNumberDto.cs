namespace OrderManagement.Core.Application.Users.DTOs;

public class PhoneNumberDto
{
    public int CountryCode { get; set; }

    public ulong NationalNumber { get; set; }
}