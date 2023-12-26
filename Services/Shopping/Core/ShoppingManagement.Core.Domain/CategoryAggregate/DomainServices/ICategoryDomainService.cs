using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;

namespace ShoppingManagement.Core.Domain.CategoryAggregate.DomainServices;

public interface ICategoryDomainService
{
    Task<Category> CreateAsync(Guid id, string name, Guid? parentId, DateTime createdAt, string createdBy);
}