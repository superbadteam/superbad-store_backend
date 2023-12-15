namespace OrderManagement.Core.Application.DTOs.ProductDTOs;

public class ProductOrderDto
{
    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public string TypeName { get; set; } = null!;

    public double PricePerUnit { get; set; }

    public string ProductName { get; set; } = null!;

    public Guid ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;
}