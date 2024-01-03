using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Specifications;

public class CartItemIsNotDeletedSpecification : Specification<Cart>
{
    public override Expression<Func<Cart, bool>> ToExpression()
    {
        return cart => cart.DeletedAt == null!;
    }
}