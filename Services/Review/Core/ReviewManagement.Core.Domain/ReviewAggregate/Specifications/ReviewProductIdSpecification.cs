using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

public class ReviewProductIdSpecification : Specification<Review>
{
    private readonly Guid _productId;

    public ReviewProductIdSpecification(Guid productId)
    {
        _productId = productId;
    }

    public override Expression<Func<Review, bool>> ToExpression()
    {
        return review => review.ProductType.ProductId == _productId;
    }
}