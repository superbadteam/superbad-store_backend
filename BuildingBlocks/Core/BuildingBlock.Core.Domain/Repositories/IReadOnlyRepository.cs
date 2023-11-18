using BuildingBlock.Core.Domain.Specifications.Abstractions;

namespace BuildingBlock.Core.Domain.Repositories;

public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
{
    Task<List<TDto>> GetAllAsync<TDto>(ISpecification<TEntity>? specification = null, string? includeTables = null);

    Task<bool> CheckIfExistAsync(ISpecification<TEntity>? specification = null);

    Task<(List<TDto>, int)> GetFilterAndPagingAsync<TDto>(ISpecification<TEntity>? specification,
        string sort, int pageIndex, int pageSize, string? includeTables = null);

    Task<TDto?> GetAnyAsync<TDto>(ISpecification<TEntity>? specification = null, string? includeTables = null);

    Task<TEntity?> GetAnyAsync(ISpecification<TEntity>? specification = null, string? includeTables = null);

    Task<List<TEntity>> GetAllAsync(ISpecification<TEntity>? specification = null, string? includeTables = null);

    Task<(List<TEntity>, int)> GetFilterAndPagingAsync(ISpecification<TEntity>? specification,
        string sort, int pageIndex, int pageSize, string? includeTables = null);
}