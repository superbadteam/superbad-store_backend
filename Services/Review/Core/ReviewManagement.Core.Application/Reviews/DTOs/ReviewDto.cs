namespace ReviewManagement.Core.Application.Reviews.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }

    public ReviewerDto Reviewer { get; set; } = null!;

    public ReviewedProductDto Product { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Likes { get; set; }
}