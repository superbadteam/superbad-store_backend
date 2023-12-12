using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.OrderAggregateConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.TotalPrice)
            .IsRequired();

        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId);

        builder.HasOne(order => order.ShippingAddress)
            .WithMany(sa => sa.Orders)
            .HasForeignKey(order => order.ShippingAddressId);
    }
}