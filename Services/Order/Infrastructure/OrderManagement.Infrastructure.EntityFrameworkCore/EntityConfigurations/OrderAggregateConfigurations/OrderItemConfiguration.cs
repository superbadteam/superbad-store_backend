using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.OrderAggregateConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasOne(orderItem => orderItem.Order)
            .WithMany(order => order.Items)
            .HasForeignKey(orderItem => orderItem.OrderId);

        builder.HasOne(orderItem => orderItem.ProductType)
            .WithMany(productType => productType.OrderItems)
            .HasForeignKey(orderItem => orderItem.ProductTypeId);

        builder.Property(orderItem => orderItem.Quantity)
            .IsRequired();

        builder.Property(orderItem => orderItem.TotalPrice)
            .IsRequired();

        builder.HasIndex(e => new { e.OrderId, e.ProductTypeId })
            .IsUnique();
    }
}