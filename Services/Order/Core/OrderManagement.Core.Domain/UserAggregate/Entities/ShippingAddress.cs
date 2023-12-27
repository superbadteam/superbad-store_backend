using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.ValueObjects;

namespace OrderManagement.Core.Domain.UserAggregate.Entities;

public class ShippingAddress : Entity
{
    public ShippingAddress(string name, PhoneNumber phoneNumber, Guid districtId, string address,
        bool isMainAddress) : this()
    {
        Name = name;
        PhoneNumber = phoneNumber;
        DistrictId = districtId;
        Address = address;
        IsMainAddress = isMainAddress;
    }

    public ShippingAddress()
    {
        Orders = new List<Order>();
    }

    public string Name { get; set; } = null!;

    public PhoneNumber PhoneNumber { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid DistrictId { get; set; }

    public Location District { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsMainAddress { get; set; }

    public List<Order> Orders { get; set; }
}