using ReviewManagement.Core.Application.Users.DTOs;

namespace ReviewManagement.Core.Application.Orders.DTOs;

public class OrderItemDto
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public string TypeName { get; set; } = null!;

    public double PricePerUnit { get; set; }

    public string ProductName { get; set; } = null!;

    public Guid ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public SellerDto Seller { get; set; } = null!;
}