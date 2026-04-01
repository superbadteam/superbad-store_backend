using AutoMapper;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Repositories;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Repositories;

public class ShippingAddressReadOnlyRepository : ReadOnlyRepository<OrderDbContext, ShippingAddress>, IShippingAddressReadOnlyRepository
{
    private readonly DbSet<ShippingAddress> _shippingAddressDbSet;
    public ShippingAddressReadOnlyRepository(OrderDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _shippingAddressDbSet = DbContext.Set<ShippingAddress>();
    }

    public async Task<List<(Location Province, int UserCount)>> GetUserDistributionAsync()
    {
        var result = await (
            from address in _shippingAddressDbSet
            join district in DbContext.Set<Location>() on address.DistrictId equals district.Id
            join province in DbContext.Set<Location>() on district.ParentId equals province.Id
            join user in DbContext.Set<User>() on address.UserId equals user.Id
            where address.DeletedAt == null && user.DeletedAt == null
            group user by new { province.Id, province.Name } into g
            select new
            {
                Province = new Location
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name
                },
                UserCount = g.Select(x => x.Id).Distinct().Count()
            }
        ).ToListAsync();

        return result.Select(x => (x.Province, x.UserCount)).ToList();
    }
}