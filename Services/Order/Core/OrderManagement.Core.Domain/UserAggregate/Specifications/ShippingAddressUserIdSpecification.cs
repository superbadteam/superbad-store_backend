using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Specifications;

public class ShippingAddressUserIdSpecification : Specification<ShippingAddress>
{
    private readonly Guid _userId;

    public ShippingAddressUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<ShippingAddress, bool>> ToExpression()
    {
        return sa => sa.UserId == _userId;
    }
}