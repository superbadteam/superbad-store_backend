using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductTypeProductIdSpecification : Specification<ProductType>
{
    private readonly Guid _productId;

    public ProductTypeProductIdSpecification(Guid productId)
    {
        _productId = productId;
    }

    public override Expression<Func<ProductType, bool>> ToExpression()
    {
        return productType => productType.ProductId == _productId;
    }
}