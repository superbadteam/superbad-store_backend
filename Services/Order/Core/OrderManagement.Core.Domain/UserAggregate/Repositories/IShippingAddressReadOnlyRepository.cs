using BuildingBlock.Core.Domain.Repositories;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Repositories;

public interface IShippingAddressReadOnlyRepository : IReadOnlyRepository<ShippingAddress>
{
    Task<List<(Location Province, int UserCount)>> GetUserDistributionAsync();
}