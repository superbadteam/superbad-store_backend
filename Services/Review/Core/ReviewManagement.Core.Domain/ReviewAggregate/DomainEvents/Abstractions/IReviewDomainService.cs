using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;

public interface IReviewDomainService
{
    Task<Review> CreateAsync(Guid orderItemId, Rating rating, Content? content, Guid userId);

    Task LikeAsync(Review review, Guid userId);
}