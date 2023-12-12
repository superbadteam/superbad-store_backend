using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ProductAggregateConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(product => product.UserId)
            .IsRequired();

        builder.Property(product => product.Condition)
            .IsRequired();

        builder.HasOne(product => product.User)
            .WithMany(user => user.Products)
            .HasForeignKey(product => product.UserId);
    }
}