namespace SaleManagement.Core.Application.DTOs.UserDTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double AverageRating { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverUrl { get; set; }

    public int ProductSold { get; set; }
}