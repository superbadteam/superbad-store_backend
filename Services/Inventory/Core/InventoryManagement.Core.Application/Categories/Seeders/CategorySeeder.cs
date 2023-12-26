using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using InventoryManagement.Core.Application.Categories.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Core.Application.Categories.Seeders;

public class CategorySeeder : IDataSeeder
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly IOperationRepository<Category> _categoryOperationRepository;
    private readonly IReadOnlyRepository<Category> _categoryReadOnlyRepository;
    private readonly IEventBus _eventBus;
    private readonly ILogger<CategorySeeder> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategorySeeder(ICategoryDomainService categoryDomainService,
        IOperationRepository<Category> categoryOperationRepository,
        IReadOnlyRepository<Category> categoryReadOnlyRepository, IUnitOfWork unitOfWork,
        ILogger<CategorySeeder> logger, IEventBus eventBus, IMapper mapper)
    {
        _categoryDomainService = categoryDomainService;
        _categoryOperationRepository = categoryOperationRepository;
        _categoryReadOnlyRepository = categoryReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _eventBus = eventBus;
        _mapper = mapper;
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

        var categories = BuildingBlock.Core.Domain.Shared.Constants.Categories.GetCategories();

        var mainCategories = categories.Select(category => _categoryDomainService.Create(category.Key)).ToList();

        await _categoryOperationRepository.AddRangeAsync(mainCategories);

        await _unitOfWork.SaveChangesAsync();

        foreach (var mainCategory in mainCategories)
        {
            var name = mainCategory.Name;

            if (!categories.TryGetValue(name, out var subCategoryNames)) continue;

            foreach (var subCategoryName in subCategoryNames)
                mainCategory.SubCategories.Add(
                    await _categoryDomainService.CreateAsync(subCategoryName, mainCategory.Id));

            _categoryOperationRepository.Update(mainCategory);
        }

        await _unitOfWork.SaveChangesAsync();


        foreach (var mainCategory in mainCategories)
        {
            _eventBus.Publish(new CategoryCreatedIntegrationEvent(_mapper.Map<CategoryCreatedPayload>(mainCategory)));

            foreach (var subCategory in mainCategory.SubCategories)
                _eventBus.Publish(
                    new CategoryCreatedIntegrationEvent(_mapper.Map<CategoryCreatedPayload>(subCategory)));
        }


        _logger.LogInformation("Category data seeded successfully!");
    }
}