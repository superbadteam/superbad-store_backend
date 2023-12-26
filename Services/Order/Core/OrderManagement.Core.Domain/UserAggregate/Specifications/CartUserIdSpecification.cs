using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.UserAggregate.Specifications;

public class CartUserIdSpecification : Specification<Cart>
{
    private readonly Guid _userId;

    public CartUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<Cart, bool>> ToExpression()
    {
        return cart => cart.UserId == _userId;
    }
}