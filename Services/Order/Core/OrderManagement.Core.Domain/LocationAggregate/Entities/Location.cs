using BuildingBlock.Core.Domain;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.LocationAggregate.Entities;

public class Location : AggregateRoot
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public Location? ParentLocation { get; set; }

    public List<Location> SubLocations { get; set; } = null!;

    public List<ShippingAddress> ShippingAddresses { get; set; } = null!;
}