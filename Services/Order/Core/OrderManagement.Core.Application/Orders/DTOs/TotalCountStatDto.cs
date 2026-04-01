namespace OrderManagement.Core.Application.Orders.DTOs;

public class TotalCountStatDto
{
    public int TotalUsers { get; set; }
    public int TotalProducts { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalSales { get; set; }
}