namespace ReviewManagement.Core.Application.Reviews.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
}