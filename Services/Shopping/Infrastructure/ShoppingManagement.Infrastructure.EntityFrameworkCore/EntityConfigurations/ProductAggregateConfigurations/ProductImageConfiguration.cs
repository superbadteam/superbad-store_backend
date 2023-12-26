using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ProductAggregateConfigurations;

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