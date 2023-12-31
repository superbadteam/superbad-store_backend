using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

public class LikedReviewReviewIdSpecification : Specification<LikedReview>
{
    private readonly Guid _reviewId;

    public LikedReviewReviewIdSpecification(Guid reviewId)
    {
        _reviewId = reviewId;
    }

    public override Expression<Func<LikedReview, bool>> ToExpression()
    {
        return likedReview => likedReview.ReviewId == _reviewId;
    }
}