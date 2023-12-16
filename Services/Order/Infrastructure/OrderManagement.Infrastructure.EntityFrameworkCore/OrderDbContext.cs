using BuildingBlock.Core.Application;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore;

public class OrderDbContext : BaseDbContext
{
    public OrderDbContext(DbContextOptions options, ICurrentUser currentUser, IMediator mediator) : base(options,
        currentUser, mediator)
    {
    }

    public DbSet<Location> Locations { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductType> ProductTypes { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<ShippingAddress> ShippingAddresses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
    }
}