using BuildingBlock.Core.Application;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using InventoryManagement.Core.Domain.CategoryAggregate.Constants;
using InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Core.Application.Seeders;

public class CategorySeeder : IDataSeeder
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly IOperationRepository<Category> _categoryOperationRepository;
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;
    private readonly ILogger<CategorySeeder> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CategorySeeder(ICategoryDomainService categoryDomainService,
        IOperationRepository<Category> categoryOperationRepository,
        IReadOnlyRepository<Category> categoryReadOnlyRepository, IUnitOfWork unitOfWork,
        ILogger<CategorySeeder> logger)
    {
        _categoryDomainService = categoryDomainService;
        _categoryOperationRepository = categoryOperationRepository;
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public int ExecutionOrder => 1;

    public async Task SeedDataAsync()
    {
        if (await _categoryReadOnlyRepository.CheckIfExistAsync())
        {
            _logger.LogInformation("Category data already seeded!");
            return;
        }

        _logger.LogInformation("Start seeding category data");

        var categories = CategoryData.GetCategories();

        var mainCategories = categories.Select(category => _categoryDomainService.Create(category.Key)).ToList();

        await _categoryOperationRepository.AddRangeAsync(mainCategories);

        await _unitOfWork.SaveChangesAsync();

        var subCategories = new List<Category>();

        foreach (var mainCategory in mainCategories)
        {
            var name = mainCategory.Name;

            if (!categories.TryGetValue(name, out var subCategoryNames)) continue;

            foreach (var subCategoryName in subCategoryNames)
                subCategories.Add(await _categoryDomainService.CreateAsync(subCategoryName, mainCategory.Id));
        }

        await _categoryOperationRepository.AddRangeAsync(subCategories);

        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Category data seeded successfully!");
    }
}