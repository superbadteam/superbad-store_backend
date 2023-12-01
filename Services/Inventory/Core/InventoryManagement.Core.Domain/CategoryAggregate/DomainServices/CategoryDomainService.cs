using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.CategoryAggregate.Exceptions;

namespace InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;

    public CategoryDomainService(IReadOnlyRepository<Category> categoryReadOnlyRepository)
    {
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
    }

    public Category Create(string name)
    {
        return new Category(name);
    }

    public async Task<Category> CreateAsync(string name, Guid parentId)
    {
        await CheckValidOnCreateAsync(parentId);

        return new Category(name, parentId);
    }

    private async Task CheckValidOnCreateAsync(Guid parentId)
    {
        await ThrowIfNotExistAsync(parentId);
    }

    private async Task ThrowIfNotExistAsync(Guid id)
    {
        var categoryIdSpecification = new EntityIdSpecification<Category>(id);

        Optional<bool>.Of(await _categoryReadOnlyRepository.CheckIfExistAsync(categoryIdSpecification))
            .ThrowIfNotExist(new CategoryNotFoundException(id));
    }
}