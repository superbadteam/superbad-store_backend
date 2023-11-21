using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(productType => productType.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(productType => productType.Quantity)
            .IsRequired();

        builder.Property(productType => productType.Price)
            .IsRequired();

        builder
            .HasOne(productImage => productImage.Product)
            .WithMany(product => product.Types)
            .HasForeignKey(productImage => productImage.ProductId);
    }
}