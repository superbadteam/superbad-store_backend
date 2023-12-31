using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Entities;

public class LikedReview : Entity
{
    public LikedReview()
    {
    }

    public LikedReview(Guid reviewId, Guid userId)
    {
        ReviewId = reviewId;
        UserId = userId;
    }

    public Guid ReviewId { get; set; }

    public Review Review { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}