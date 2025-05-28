using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;

public interface ICategoryDomainService
{
    Task<Category> CreateAsync(string name);

    Task<Category> CreateAsync(string name, Guid parentId);
}