using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Specifications;

public class ShippingAddressIsMainAddressSpecification : Specification<ShippingAddress>
{
    public override Expression<Func<ShippingAddress, bool>> ToExpression()
    {
        return sa => sa.IsMainAddress == true;
    }
}