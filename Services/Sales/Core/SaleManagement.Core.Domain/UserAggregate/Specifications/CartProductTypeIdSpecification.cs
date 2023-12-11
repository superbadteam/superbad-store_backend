using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Specifications;

public class CartProductTypeIdSpecification : Specification<Cart>
{
    private readonly Guid _productTypeId;
    private readonly Guid _userId;

    public CartProductTypeIdSpecification(Guid userId, Guid productTypeId)
    {
        _productTypeId = productTypeId;
        _userId = userId;
    }

    public override Expression<Func<Cart, bool>> ToExpression()
    {
        return cart => cart.UserId == _userId && cart.ProductTypeId == _productTypeId;
    }
}