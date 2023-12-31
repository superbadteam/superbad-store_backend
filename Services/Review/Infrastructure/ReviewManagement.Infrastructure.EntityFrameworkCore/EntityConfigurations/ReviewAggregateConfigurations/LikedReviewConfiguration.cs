using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReviewAggregateConfigurations;

public class LikedReviewConfiguration : IEntityTypeConfiguration<LikedReview>
{
    public void Configure(EntityTypeBuilder<LikedReview> builder)
    {
        builder.HasIndex(likedReview => new { likedReview.ReviewId, likedReview.UserId })
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");

        builder.HasOne(likedReview => likedReview.Review)
            .WithMany(review => review.LikedReviews)
            .HasForeignKey(likedReview => likedReview.ReviewId);

        builder.HasOne(likedReview => likedReview.User)
            .WithMany(user => user.LikedReviews)
            .HasForeignKey(likedReview => likedReview.UserId);
    }
}