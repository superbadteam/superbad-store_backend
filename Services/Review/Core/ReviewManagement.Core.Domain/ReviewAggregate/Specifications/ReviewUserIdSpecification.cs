using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

public class ReviewUserIdSpecification : Specification<Review>
{
    private readonly Guid _userId;

    public ReviewUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<Review, bool>> ToExpression()
    {
        return review => review.UserId == _userId;
    }
}