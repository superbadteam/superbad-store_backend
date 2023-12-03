using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductCategoryIdSpecification : Specification<Product>
{
    private readonly Guid _id;

    public ProductCategoryIdSpecification(Guid id)
    {
        _id = id;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => product.CategoryId == _id;
    }
}