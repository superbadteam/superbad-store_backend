using SaleManagement.Core.Domain.CategoryAggregate.Entities;

namespace SaleManagement.Core.Domain.CategoryAggregate.DomainServices;

public interface ICategoryDomainService
{
    Category Create(string name);

    Task<Category> CreateAsync(string name, Guid parentId);
}