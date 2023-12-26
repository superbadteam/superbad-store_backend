namespace SaleManagement.Core.Application.Users.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double AverageRating { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverUrl { get; set; }

    public int ProductSold { get; set; }
}