using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ProductAggregateConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.Property(p => p.Url)
            .IsRequired();

        builder
            .HasOne(productImage => productImage.Product)
            .WithMany(product => product.Images)
            .HasForeignKey(productImage => productImage.ProductId);
    }
}