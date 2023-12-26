using System.Text.Json.Serialization;
using BuildingBlock.Core.Application.DTOs;
using SaleManagement.Core.Application.Products.DTOs.Enums;
using SaleManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace SaleManagement.Core.Application.Products.DTOs;

public class FilterAndPagingProductsDto : FilterAndPagingDto<ProductSortProperty>
{
    private string? _category;

    public string? Category
    {
        get => _category;
        set
        {
            _category = value;
            CategoryIds = ConvertCategoryFilter();
        }
    }

    [JsonIgnore] public List<Guid> CategoryIds { get; set; } = new();

    public ProductCondition? Condition { get; set; }

    private List<Guid> ConvertCategoryFilter()
    {
        if (_category == null) return new List<Guid>();

        var categoryStringIds = _category.Split(new[] { ',' }, StringSplitOptions.TrimEntries);

        var categoryGuidIds = new List<Guid>();

        foreach (var stringId in categoryStringIds)
            if (Guid.TryParse(stringId, out var guidId))
                categoryGuidIds.Add(guidId);

        return categoryGuidIds;
    }
}