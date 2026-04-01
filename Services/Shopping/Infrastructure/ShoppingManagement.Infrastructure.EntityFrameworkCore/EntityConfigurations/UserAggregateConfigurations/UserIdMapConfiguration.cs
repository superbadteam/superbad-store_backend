using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.UserAggregateConfigurations;

public class UserIdMapConfiguration : IEntityTypeConfiguration<UserIdMap>
{
    public void Configure(EntityTypeBuilder<UserIdMap> builder)
    {
        builder.HasIndex(u => new { u.GuidUserId, u.StringUserId }).IsUnique();
    }
}