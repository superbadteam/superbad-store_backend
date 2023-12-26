using AutoMapper;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;
using InventoryManagement.Core.Application.Products.IntegrationEvents.Events;
using InventoryManagement.Core.Application.Products.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.DomainServices.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Handlers;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDetailDto>
{
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IOperationRepository<Product> _operationRepository;
    private readonly IProductDomainService _productDomainService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductDomainService productDomainService, IMapper mapper,
        IOperationRepository<Product> operationRepository, IUnitOfWork unitOfWork, IEventBus eventBus)
    {
        _productDomainService = productDomainService;
        _mapper = mapper;
        _operationRepository = operationRepository;
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
    }

    public async Task<ProductDetailDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productDomainService.CreateAsync(request.Dto.Name, request.Dto.Description,
            request.Dto.CategoryId, request.Dto.Condition);

        foreach (var productTypeDto in request.Dto.Types)
            _productDomainService.CreateProductType(product, productTypeDto.Name,
                productTypeDto.Quantity, productTypeDto.Price, productTypeDto.ImageUrl);

        foreach (var productImageDto in request.Dto.Images)
            _productDomainService.CreateProductImage(product, productImageDto.Url);

        await _operationRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new ProductCreatedIntegrationEvent(_mapper.Map<ProductCreatedPayload>(product)));

        return _mapper.Map<ProductDetailDto>(product);
    }
}