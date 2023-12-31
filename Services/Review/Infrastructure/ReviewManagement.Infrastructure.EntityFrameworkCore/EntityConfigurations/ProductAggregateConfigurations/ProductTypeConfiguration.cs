using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ProductAggregateConfigurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(productType => productType.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .HasOne(productImage => productImage.Product)
            .WithMany(product => product.Types)
            .HasForeignKey(productImage => productImage.ProductId);
    }
}