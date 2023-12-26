using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.UserAggregateConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(user => user.AverageRating)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(user => user.ProductSold)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(user => user.TotalPrice)
            .IsRequired()
            .HasDefaultValue(0);
    }
}