using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.UserAggregateConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(320)
            .IsRequired();
    }
}