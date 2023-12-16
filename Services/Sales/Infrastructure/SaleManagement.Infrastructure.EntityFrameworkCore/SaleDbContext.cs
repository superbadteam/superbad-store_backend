using BuildingBlock.Core.Application;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Entities;

namespace SaleManagement.Infrastructure.EntityFrameworkCore;

public class SaleDbContext : BaseDbContext
{
    public SaleDbContext(DbContextOptions options, ICurrentUser currentUser, IMediator mediator) : base(options,
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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaleDbContext).Assembly);
    }
}