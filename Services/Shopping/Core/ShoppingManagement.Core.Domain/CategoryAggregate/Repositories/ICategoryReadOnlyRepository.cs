using BuildingBlock.Core.Domain.Repositories;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;

namespace ShoppingManagement.Core.Domain.CategoryAggregate.Repositories;

public interface ICategoryReadOnlyRepository : IReadOnlyRepository<Category>
{
    Task<List<(Category, int)>> GetCategoriesWithSalesAsync();
}