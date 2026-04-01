using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductIdSpecification : Specification<Product>
{
    private readonly IEnumerable<Guid> _productIds;

    public ProductIdSpecification(IEnumerable<Guid> productIds)
    {
        _productIds = productIds;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => _productIds.Contains(product.Id);
    }
}