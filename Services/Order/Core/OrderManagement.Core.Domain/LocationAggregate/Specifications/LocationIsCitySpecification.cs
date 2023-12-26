using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.LocationAggregate.Entities;

namespace OrderManagement.Core.Domain.LocationAggregate.Specifications;

public class LocationIsCitySpecification : Specification<Location>
{
    public override Expression<Func<Location, bool>> ToExpression()
    {
        return location => location.ParentLocation == null;
    }
}