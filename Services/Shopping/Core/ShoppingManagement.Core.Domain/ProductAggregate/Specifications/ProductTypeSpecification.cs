using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductTypeSpecification : Specification<Product>
{
    private readonly ProductCondition? _type;

    public ProductTypeSpecification(ProductCondition? type)
    {
        _type = type;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        // if (_type == null) return product => true;
        //
        // return product => product.Type == _type;

        throw new NotImplementedException();
    }
}