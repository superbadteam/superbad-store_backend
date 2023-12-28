using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ReviewAggregateConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(review => review.ProductTypeId)
            .IsRequired();

        builder.Property(review => review.UserId)
            .IsRequired();

        builder.Property(review => review.Rating)
            .HasConversion(rating => rating.Value, value => new Rating(value))
            .IsRequired();

        builder.Property(review => review.Content)
            .HasConversion(content => content!.Value, value => new Content(value));

        builder.HasOne(review => review.ProductType)
            .WithMany(productType => productType.Reviews)
            .HasForeignKey(review => review.ProductTypeId);

        builder.HasOne(review => review.User)
            .WithMany(user => user.Reviews)
            .HasForeignKey(review => review.UserId);

        builder.HasOne(review => review.Parent)
            .WithMany(review => review.Replies)
            .HasForeignKey(review => review.ParentId);
    }
}