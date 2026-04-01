using AutoMapper;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Domain.OrderAggregate.Entities;
using OrderManagement.Core.Domain.OrderAggregate.Repositories;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Repositories;

public class OrderReadOnlyRepository : ReadOnlyRepository<OrderDbContext, Order>, IOrderReadOnlyRepository
{
    public OrderReadOnlyRepository(OrderDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public Task<decimal> GetTotalSalesAsync()
    {
        return DbSet.AsNoTracking()
            .SumAsync(order => (decimal)order.TotalPrice);
    }

    public async Task<List<(int Year, int Month, double Total)>> GetMonthlySalesAsync(params int[] years)
    {
        var grouped = await DbSet
            .Where(o => years.Contains(o.CreatedAt.Year))
            .GroupBy(o => new { o.CreatedAt.Year, o.CreatedAt.Month })
            .Select(g => new ValueTuple<int, int, double>(
                g.Key.Year,
                g.Key.Month,
                g.Sum(o => o.TotalPrice)
            ))
            .ToListAsync();

        return grouped;
    }
}