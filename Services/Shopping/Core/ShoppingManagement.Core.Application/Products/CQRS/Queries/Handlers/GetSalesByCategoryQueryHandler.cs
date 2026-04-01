using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Categories.DTOs;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Domain.CategoryAggregate.Repositories;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetSalesByCategoryQueryHandler : IQueryHandler<GetSalesByCategoryQuery, List<CategoryDto>>
{
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository;

    public GetSalesByCategoryQueryHandler(ICategoryReadOnlyRepository categoryReadOnlyRepository)
    {
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetSalesByCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryReadOnlyRepository.GetCategoriesWithSalesAsync();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Item1.Id,
            Name = c.Item1.Name,
            Sold = c.Item2
        }).ToList();
    }
}