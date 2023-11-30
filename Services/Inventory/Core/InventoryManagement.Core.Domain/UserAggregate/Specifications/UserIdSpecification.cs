using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.UserAggregate.Entities;

namespace InventoryManagement.Core.Domain.UserAggregate.Specifications;

public class UserIdSpecification : Specification<User>
{
    private readonly Guid _userId;

    public UserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Id == _userId;
    }
}