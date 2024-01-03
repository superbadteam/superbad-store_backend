using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.ProductAggregateConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(product => product.User)
            .WithMany(user => user.Products)
            .HasForeignKey(product => product.UserId);

        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(256);
    }
}