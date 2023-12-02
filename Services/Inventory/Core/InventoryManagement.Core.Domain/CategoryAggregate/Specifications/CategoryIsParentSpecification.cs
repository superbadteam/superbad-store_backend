using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Specifications;

public class CategoryIsParentSpecification : Specification<Category>
{
    public override Expression<Func<Category, bool>> ToExpression()
    {
        return category => category.ParentId == null;
    }
}