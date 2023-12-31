using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using InventoryManagement.Core.Application.Categories.CQRS.Queries.Requests;
using InventoryManagement.Core.Application.Categories.DTOs;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.CategoryAggregate.Specifications;

namespace InventoryManagement.Core.Application.Categories.CQRS.Queries.Handlers;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IReadOnlyRepository<Category> _categoryReadonlyRepository;

    public GetAllCategoriesQueryHandler(IReadOnlyRepository<Category> categoryReadonlyRepository)
    {
        _categoryReadonlyRepository = categoryReadonlyRepository;
    }

    public Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoryIsParentSpecification = new CategoryIsParentSpecification();

        return _categoryReadonlyRepository
            .InitQueryBuilder()
            .AsNoTracking()
            .Where(categoryIsParentSpecification)
            .OrderBy("Name")
            .ToListAsync<CategoryDto>();
    }
}