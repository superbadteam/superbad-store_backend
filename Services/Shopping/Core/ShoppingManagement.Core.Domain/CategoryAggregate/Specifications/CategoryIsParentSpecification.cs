using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;

namespace ShoppingManagement.Core.Domain.CategoryAggregate.Specifications;

public class CategoryIsParentSpecification : Specification<Category>
{
    public override Expression<Func<Category, bool>> ToExpression()
    {
        return category => category.ParentId == null;
    }
}