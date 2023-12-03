using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;

namespace SaleManagement.Core.Domain.CategoryAggregate.Specifications;

public class CategoryIsParentSpecification : Specification<Category>
{
    public override Expression<Func<Category, bool>> ToExpression()
    {
        return category => category.ParentId == null;
    }
}