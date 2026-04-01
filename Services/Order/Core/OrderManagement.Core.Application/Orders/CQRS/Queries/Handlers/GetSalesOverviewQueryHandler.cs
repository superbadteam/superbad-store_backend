using System.Globalization;
using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Orders.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Domain.OrderAggregate.Repositories;

namespace OrderManagement.Core.Application.Orders.CQRS.Queries.Handlers;

public class GetSalesOverviewQueryHandler : IQueryHandler<GetSalesOverviewQuery, SalesOverviewResponse>
{
    private readonly IOrderReadOnlyRepository _orderReadOnlyRepository;

    public GetSalesOverviewQueryHandler(IOrderReadOnlyRepository orderReadOnlyRepository)
    {
        _orderReadOnlyRepository = orderReadOnlyRepository;
    }

    public async Task<SalesOverviewResponse> Handle(GetSalesOverviewQuery request, CancellationToken cancellationToken)
    {
        var currentYear = DateTime.UtcNow.Year;
        var lastYear = currentYear - 1;

        var totalSales = await _orderReadOnlyRepository.GetTotalSalesAsync();
        var monthlySales = await _orderReadOnlyRepository.GetMonthlySalesAsync(currentYear, lastYear);


        var currentYearSales = new Dictionary<string, decimal>();
        var lastYearSales = new Dictionary<string, decimal>();

        for (var month = 1; month <= 12; month++)
        {
            var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

            var current = monthlySales.FirstOrDefault(x => x.Year == currentYear && x.Month == month);
            var previous = monthlySales.FirstOrDefault(x => x.Year == lastYear && x.Month == month);

            currentYearSales[monthName] = (decimal)current.Total;
            lastYearSales[monthName] = (decimal)previous.Total;
        }

        var totalSalesCurrentYear = currentYearSales.Values.Sum();
        var totalSalesPreviousYear = lastYearSales.Values.Sum();

        var yoyChange = totalSalesPreviousYear == 0
            ? 0
            : Math.Round(
                (double)(totalSalesCurrentYear - totalSalesPreviousYear) / (double)totalSalesPreviousYear * 100, 2);

        return new SalesOverviewResponse
        {
            CurrentYear = currentYear,
            ComparisonYear = lastYear,
            TotalSales = totalSales,
            YearOverYearChange = yoyChange,
            MonthlySales = new MonthlySalesData
            {
                CurrentYear = currentYearSales,
                ComparisonYear = lastYearSales
            }
        };
    }
}