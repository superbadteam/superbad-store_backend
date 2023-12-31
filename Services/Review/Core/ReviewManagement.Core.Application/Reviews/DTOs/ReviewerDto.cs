namespace ReviewManagement.Core.Application.Reviews.DTOs;

public class ReviewerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? AvatarUrl { get; set; }
}