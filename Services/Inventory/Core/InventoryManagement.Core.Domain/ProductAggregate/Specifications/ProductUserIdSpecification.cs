using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductUserIdSpecification : Specification<Product>
{
    private readonly Guid _userId;

    public ProductUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        return product => product.UserId == _userId;
    }
}