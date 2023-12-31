using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.OrderAggregateConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasOne(orderItem => orderItem.ProductType)
            .WithMany(productType => productType.OrderItems)
            .HasForeignKey(orderItem => orderItem.ProductTypeId);

        builder.HasOne(orderItem => orderItem.User)
            .WithMany(user => user.OrderItems)
            .HasForeignKey(orderItem => orderItem.UserId);

        builder.Property(orderItem => orderItem.ProductTypeId)
            .IsRequired();

        builder.Property(orderItem => orderItem.UserId)
            .IsRequired();
    }
}