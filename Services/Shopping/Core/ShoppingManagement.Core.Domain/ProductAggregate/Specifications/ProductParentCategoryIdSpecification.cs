using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductParentCategoryIdSpecification : Specification<Product>
{
    private readonly Guid _categoryId;

    public ProductParentCategoryIdSpecification(Guid categoryId)
    {
        _categoryId = categoryId;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => product.Category.ParentId == _categoryId;
    }
}