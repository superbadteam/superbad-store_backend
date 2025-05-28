namespace ReviewManagement.Core.Application.Reviews.DTOs;

public class CreateReviewDto
{
    public string? Content { get; set; }

    public int Rating { get; set; }
}

public class MigrateReviewDto : CreateReviewDto
{
    public string ProductTypeId { get; set; }
    public string UserId { get; set; }
}