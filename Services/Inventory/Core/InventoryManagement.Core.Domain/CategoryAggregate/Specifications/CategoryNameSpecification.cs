using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Specifications;

public class CategoryNameSpecification : Specification<Category>
{
    private readonly string _name;

    public CategoryNameSpecification(string name)
    {
        _name = name;
    }

    public override Expression<Func<Category, bool>> ToExpression()
    {
        return category => category.Name.ToLower() == _name.ToLower();
    }
}