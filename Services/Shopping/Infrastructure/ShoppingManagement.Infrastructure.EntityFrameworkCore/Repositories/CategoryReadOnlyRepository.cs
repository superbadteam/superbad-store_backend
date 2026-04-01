using AutoMapper;
using BuildingBlock.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;
using ShoppingManagement.Core.Domain.CategoryAggregate.Repositories;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Repositories;

public class CategoryReadOnlyRepository : ReadOnlyRepository<ShoppingDbContext, Category>, ICategoryReadOnlyRepository
{
    public CategoryReadOnlyRepository(ShoppingDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<List<(Category, int)>> GetCategoriesWithSalesAsync()
    {
        var category = await DbSet
            .Select(category => new
            {
                Category = category,
                TotalSold = category.Products.Sum(product => product.Sold)
            })
            .OrderByDescending(x => x.TotalSold).ToListAsync();

        return category.Select(x => (x.Category, x.TotalSold)).ToList();
    }
}