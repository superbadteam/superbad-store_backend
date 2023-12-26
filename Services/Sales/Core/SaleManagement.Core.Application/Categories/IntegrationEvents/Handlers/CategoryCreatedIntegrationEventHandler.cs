using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using SaleManagement.Core.Application.Categories.IntegrationEvents.Events;
using SaleManagement.Core.Domain.CategoryAggregate.DomainServices;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;

namespace SaleManagement.Core.Application.Categories.IntegrationEvents.Handlers;

public class CategoryCreatedIntegrationEventHandler : IIntegrationEventHandler<CategoryCreatedIntegrationEvent>
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly IOperationRepository<Category> _categoryOperationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCreatedIntegrationEventHandler(ICategoryDomainService categoryDomainService,
        IOperationRepository<Category> categoryOperationRepository, IUnitOfWork unitOfWork)
    {
        _categoryDomainService = categoryDomainService;
        _categoryOperationRepository = categoryOperationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CategoryCreatedIntegrationEvent @event)
    {
        var category = await _categoryDomainService.CreateAsync(@event.Category.Id, @event.Category.Name,
            @event.Category.ParentId, @event.Category.CreatedAt, @event.Category.CreatedBy);

        await _categoryOperationRepository.AddAsync(category);

        await _unitOfWork.SaveChangesAsync();
    }
}