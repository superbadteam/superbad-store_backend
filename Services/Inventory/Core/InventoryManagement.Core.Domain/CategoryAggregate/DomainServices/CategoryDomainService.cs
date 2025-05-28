using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using InventoryManagement.Core.Domain.CategoryAggregate.Exceptions;
using InventoryManagement.Core.Domain.CategoryAggregate.Specifications;

namespace InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;

    public CategoryDomainService(IReadOnlyRepository<Category> categoryReadOnlyRepository)
    {
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
    }

    public async Task<Category> CreateAsync(string name)
    {
        await CheckValidOnCreatingAsync(name);

        return new Category(name);
    }

    public async Task<Category> CreateAsync(string name, Guid parentId)
    {
        await CheckValidOnCreatingAsync(name, parentId);

        return new Category(name, parentId);
    }

    private async Task CheckValidOnCreatingAsync(string name, Guid? parentId = null)
    {
        await ThrowIfExistAsync(name);

        if (parentId is null) return;

        await ThrowIfNotExistAsync(parentId.Value);
    }

    private async Task ThrowIfNotExistAsync(Guid id)
    {
        var categoryIdSpecification = new EntityIdSpecification<Category>(id);

        Optional<bool>.Of(await _categoryReadOnlyRepository.CheckIfExistAsync(categoryIdSpecification))
            .ThrowIfNotExist(new CategoryNotFoundException(id));
    }

    private async Task ThrowIfExistAsync(string name)
    {
        var categoryNameSpecification = new CategoryNameSpecification(name);

        Optional<bool>.Of(await _categoryReadOnlyRepository.CheckIfExistAsync(categoryNameSpecification))
            .ThrowIfExist(new CategoryConflictException(name));
    }
}