namespace ShoppingManagement.Core.Application.Categories.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Sold { get; set; }
}