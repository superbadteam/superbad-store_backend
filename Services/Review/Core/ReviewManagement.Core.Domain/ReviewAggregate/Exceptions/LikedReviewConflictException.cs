using BuildingBlock.Core.Domain.Exceptions;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Exceptions;

public class LikedReviewConflictException : EntityConflictException
{
    public LikedReviewConflictException(Guid reviewId, Guid userId) : base(
        $"User with id: {userId} already liked review with id: {reviewId}")
    {
    }
}