using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;
using SaleManagement.Core.Domain.CategoryAggregate.Exceptions;

namespace SaleManagement.Core.Domain.CategoryAggregate.DomainServices;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;

    public CategoryDomainService(IReadOnlyRepository<Category> categoryReadOnlyRepository)
    {
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
    }

    public async Task<Category> CreateAsync(Guid id, string name, Guid? parentId, DateTime createdAt, string createdBy)
    {
        await CheckValidOnCreateAsync(id, parentId);

        return new Category(id, name, parentId, createdAt, createdBy);
    }

    private async Task CheckValidOnCreateAsync(Guid id, Guid? parentId)
    {
        await ThrowIfCategoryIsExist(id);

        if (parentId == null) return;

        await ThrowIfCategoryIsNotExist(parentId.Value);
    }

    private async Task ThrowIfCategoryIsExist(Guid id)
    {
        var categoryIdSpecification = new EntityIdSpecification<Category>(id);

        Optional<bool>.Of(await _categoryReadOnlyRepository.CheckIfExistAsync(categoryIdSpecification))
            .ThrowIfExist(new CategoryConflictException(id));
    }

    private async Task ThrowIfCategoryIsNotExist(Guid id)
    {
        var categoryIdSpecification = new EntityIdSpecification<Category>(id);

        Optional<bool>.Of(await _categoryReadOnlyRepository.CheckIfExistAsync(categoryIdSpecification))
            .ThrowIfNotExist(new CategoryNotFoundException(id));
    }
}