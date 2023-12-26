using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Core.Domain.UserAggregate.Specifications;

public class CartProductIdSpecification : Specification<Cart>
{
    private readonly Guid _productTypeId;
    private readonly Guid _userId;

    public CartProductIdSpecification(Guid userId, Guid productTypeId)
    {
        _userId = userId;
        _productTypeId = productTypeId;
    }

    public override Expression<Func<Cart, bool>> ToExpression()
    {
        return cart => cart.UserId == _userId && cart.ProductTypeId == _productTypeId;
    }
}