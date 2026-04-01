using AutoMapper;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;
using InventoryManagement.Core.Application.Products.IntegrationEvents.Events;
using InventoryManagement.Core.Application.Products.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.DomainServices.Abstractions;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Exceptions;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Handlers;

public class EditProductCommandHandler : ICommandHandler<EditProductCommand, ProductDetailDto>
{
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IOperationRepository<Product> _operationRepository;
    private readonly IProductDomainService _productDomainService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public EditProductCommandHandler(IProductDomainService productDomainService, IMapper mapper,
        IOperationRepository<Product> operationRepository, IUnitOfWork unitOfWork, IEventBus eventBus, IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _productDomainService = productDomainService;
        _mapper = mapper;
        _operationRepository = operationRepository;
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<ProductDetailDto> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(request.ProductId);
        var product = await _productReadOnlyRepository.GetAnyAsync(productIdSpecification, "Types", false, true) ?? throw new ProductNotFoundException(request.ProductId);

        foreach (var productType in product.Types)
        {
            productType.Quantity = 10000;
        }

        await _unitOfWork.SaveChangesAsync();
        // var product = await _productDomainService.EditAsync(request.ProductId, request.Dto.Code, request.Dto.Name,
        //     request.Dto.Price, request.Dto.IsAvailable, request.Dto.Type);

        // _operationRepository.Update(product);

        // await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new ProductEditedIntegrationEvent(product.Id, 10000));

        return _mapper.Map<ProductDetailDto>(product);
    }
}