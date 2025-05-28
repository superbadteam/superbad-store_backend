using AutoMapper;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using InventoryManagement.Core.Application.Categories.CQRS.Commands.Requests;
using InventoryManagement.Core.Application.Categories.DTOs;
using InventoryManagement.Core.Application.Categories.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.CategoryAggregate.DomainServices;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Core.Application.Categories.CQRS.Commands.Handlers;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryDomainService _domainService;
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IOperationRepository<Category> _operationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IEventBus eventBus, IMapper mapper, IUnitOfWork unitOfWork,
        ICategoryDomainService domainService, IOperationRepository<Category> operationRepository)
    {
        _eventBus = eventBus;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _domainService = domainService;
        _operationRepository = operationRepository;
    }

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _domainService.CreateAsync(request.Dto.Name);

        await _operationRepository.AddAsync(category);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new CategoryCreatedIntegrationEvent(_mapper.Map<CategoryCreatedPayload>(category)));

        return _mapper.Map<CategoryDto>(category);
    }
}