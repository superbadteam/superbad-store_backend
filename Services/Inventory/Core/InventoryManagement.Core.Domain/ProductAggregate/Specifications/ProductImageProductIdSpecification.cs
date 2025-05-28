using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductImageProductIdSpecification : Specification<ProductImage>
{
    private readonly Guid _productId;

    public ProductImageProductIdSpecification(Guid productId)
    {
        _productId = productId;
    }

    public override Expression<Func<ProductImage, bool>> ToExpression()
    {
        return productType => productType.ProductId == _productId;
    }
}