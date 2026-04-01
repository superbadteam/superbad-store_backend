namespace OrderManagement.Core.Application.Orders.DTOs;

public class SalesOverviewResponse
{
    public int CurrentYear { get; set; }
    public int ComparisonYear { get; set; }
    public decimal TotalSales { get; set; }
    public double YearOverYearChange { get; set; }
    public MonthlySalesData MonthlySales { get; set; } = null!;
}

public class MonthlySalesData
{
    public Dictionary<string, decimal> CurrentYear { get; set; } = null!;
    public Dictionary<string, decimal> ComparisonYear { get; set; } = null!;
}