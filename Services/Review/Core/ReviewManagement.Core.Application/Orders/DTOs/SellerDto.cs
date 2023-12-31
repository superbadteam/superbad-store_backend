namespace ReviewManagement.Core.Application.Orders.DTOs;

public class SellerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;
}