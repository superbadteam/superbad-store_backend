using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.EntityConfigurations.CategoryAggregateConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasOne(category => category.Parent)
            .WithMany(category => category.SubCategories)
            .HasForeignKey(category => category.ParentId);
    }
}