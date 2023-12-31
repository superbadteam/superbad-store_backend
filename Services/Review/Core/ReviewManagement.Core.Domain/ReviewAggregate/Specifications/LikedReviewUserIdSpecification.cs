using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

public class LikedReviewUserIdSpecification : Specification<LikedReview>
{
    private readonly Guid _userId;

    public LikedReviewUserIdSpecification(Guid userId)
    {
        _userId = userId;
    }

    public override Expression<Func<LikedReview, bool>> ToExpression()
    {
        return likedReview => likedReview.UserId == _userId;
    }
}