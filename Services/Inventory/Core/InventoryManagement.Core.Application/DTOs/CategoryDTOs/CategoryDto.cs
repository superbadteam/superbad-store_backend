namespace InventoryManagement.Core.Application.DTOs.CategoryDTOs;

public class CategoryDto
{
    public string Name { get; set; } = null!;

    public Guid Id { get; set; }

    public IEnumerable<CategoryDto> SubCategories { get; set; } = null!;
}