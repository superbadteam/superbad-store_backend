using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.LocationAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.LocationAggregateConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(location => location.Name)
            .IsRequired();

        builder.Property(location => location.Code)
            .IsRequired();

        builder.HasOne(location => location.ParentLocation)
            .WithMany(location => location.SubLocations)
            .HasForeignKey(location => location.ParentId);

        builder.HasIndex(location => location.Code)
            .IsUnique().HasFilter("\"DeletedAt\" IS NULL");
    }
}