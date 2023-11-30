using InventoryManagement.Core.Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations;

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
    }
}