using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Entities;

public class ShippingAddress : Entity
{
    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid DistrictId { get; set; }

    public Location District { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsMainAddress { get; set; }

    public List<Order> Orders { get; set; } = null!;
}