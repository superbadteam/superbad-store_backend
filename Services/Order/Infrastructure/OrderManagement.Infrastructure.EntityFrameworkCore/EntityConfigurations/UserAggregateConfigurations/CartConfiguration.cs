using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.UserAggregateConfigurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(cart => cart.Id).ValueGeneratedNever();

        builder.HasIndex(cart => new { cart.UserId, cart.ProductTypeId })
            .IsUnique().HasFilter("\"DeletedAt\" IS NULL");

        builder.Property(cart => cart.TotalPrice)
            .IsRequired();

        builder.Property(cart => cart.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder.HasOne(cart => cart.User)
            .WithMany(user => user.Carts)
            .HasForeignKey(cart => cart.UserId);

        builder.HasOne(cart => cart.ProductType)
            .WithMany(productType => productType.Carts)
            .HasForeignKey(cart => cart.ProductTypeId);
    }
}