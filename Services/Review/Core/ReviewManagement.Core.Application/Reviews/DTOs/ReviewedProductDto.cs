namespace ReviewManagement.Core.Application.Reviews.DTOs;

public class ReviewedProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string TypeName { get; set; } = null!;
}