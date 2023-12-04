using BuildingBlock.Core.Application;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore;

public class InventoryDbContext : BaseDbContext
{
    public InventoryDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options, currentUser)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    public DbSet<ProductImage> ProductImages { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
    }
}