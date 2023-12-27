using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.UserAggregateConfigurations;

public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAddress>
{
    public void Configure(EntityTypeBuilder<ShippingAddress> builder)
    {
        builder.HasOne(sa => sa.User)
            .WithMany(sa => sa.ShippingAddresses)
            .HasForeignKey(sa => sa.UserId);

        builder.HasOne(sa => sa.District)
            .WithMany(location => location.ShippingAddresses)
            .HasForeignKey(sa => sa.DistrictId);

        builder.Property(sa => sa.Name)
            .IsRequired()
            .HasMaxLength(320);

        builder.OwnsOne(sa => sa.PhoneNumber, phoneNumber =>
        {
            phoneNumber.Property(pn => pn.CountryCode)
                .IsRequired();

            phoneNumber.Property(pn => pn.NationalNumber)
                .IsRequired();
        });

        builder.HasIndex(sa => new { sa.UserId, sa.IsMainAddress })
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL AND \"IsMainAddress\" = true");
    }
}