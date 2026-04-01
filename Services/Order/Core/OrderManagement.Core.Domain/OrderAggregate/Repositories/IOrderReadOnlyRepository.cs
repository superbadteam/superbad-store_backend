using BuildingBlock.Core.Domain.Repositories;
using OrderManagement.Core.Domain.OrderAggregate.Entities;

namespace OrderManagement.Core.Domain.OrderAggregate.Repositories;

public interface IOrderReadOnlyRepository : IReadOnlyRepository<Order>
{
    Task<decimal> GetTotalSalesAsync();

    Task<List<(int Year, int Month, double Total)>> GetMonthlySalesAsync(params int[] years);
}