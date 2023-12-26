using BuildingBlock.Core.Application;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore;

public class ShoppingDbContext : BaseDbContext
{
    public ShoppingDbContext(DbContextOptions options, ICurrentUser currentUser, IMediator mediator) : base(options,
        currentUser, mediator)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    public DbSet<ProductImage> ProductImages { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingDbContext).Assembly);
    }
}