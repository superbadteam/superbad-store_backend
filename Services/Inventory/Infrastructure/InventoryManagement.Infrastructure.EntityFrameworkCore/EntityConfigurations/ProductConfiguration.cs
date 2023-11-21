using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(product => product.Description)
            .IsRequired();

        builder.Property(product => product.UserId)
            .IsRequired();

        builder.Property(product => product.CategoryId)
            .IsRequired();

        builder.Property(product => product.Sold)
            .IsRequired();

        builder.Property(product => product.Condition)
            .IsRequired();

        builder.Property(product => product.Rating)
            .IsRequired();

        builder.Property(product => product.TotalReviews)
            .IsRequired();

        builder.Property(product => product.MinPrice)
            .IsRequired();
        
        builder.Property(product => product.MaxPrice)
            .IsRequired();

        builder.HasOne(product => product.User)
            .WithMany(user => user.Products)
            .HasForeignKey(product => product.UserId);

        builder.HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId);
    }
}