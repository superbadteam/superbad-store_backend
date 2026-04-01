using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Domain.UserAggregate.Specifications;

public class UserIdMapGuidSpecification : Specification<UserIdMap>
{
    private readonly Guid _guidUserId;

    public UserIdMapGuidSpecification(Guid guidUserId)
    {
        _guidUserId = guidUserId;
    }

    public override Expression<Func<UserIdMap, bool>> ToExpression()
    {
        return userIdMap => userIdMap.GuidUserId == _guidUserId;
    }
}