using BuildingBlock.Core.Domain.Exceptions;
using OrderManagement.Core.Domain.LocationAggregate.Entities;

namespace OrderManagement.Core.Domain.LocationAggregate.Exceptions;

public class DistrictNotFoundException : EntityNotFoundException
{
    public DistrictNotFoundException(Guid id) : base(nameof(Location), id)
    {
    }
}