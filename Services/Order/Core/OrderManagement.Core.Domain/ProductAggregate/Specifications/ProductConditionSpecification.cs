using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace OrderManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductConditionSpecification : Specification<Product>
{
    private readonly ProductCondition? _productCondition;

    public ProductConditionSpecification(ProductCondition? productCondition)
    {
        _productCondition = productCondition;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        if (_productCondition == null) return product => true;

        return product => product.Condition == _productCondition;
    }
}