using AutoMapper;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Requests;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.DomainServices;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Handlers;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDetailDto>
{
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IOperationRepository<Product> _operationRepository;
    private readonly IProductDomainService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductDomainService productService, IMapper mapper,
        IOperationRepository<Product> operationRepository, IUnitOfWork unitOfWork, IEventBus eventBus)
    {
        _productService = productService;
        _mapper = mapper;
        _operationRepository = operationRepository;
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
    }

    public async Task<ProductDetailDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productService.CreateAsync(request.Dto.Name, request.Dto.Description,
            request.Dto.CategoryId, request.Dto.Condition);

        var minPrice = double.MaxValue;
        var maxPrice = double.MinValue;

        foreach (var productTypeDto in request.Dto.Types)
        {
            var productType = _productService.CreateProductType(product, productTypeDto.Name, productTypeDto.Quantity,
                productTypeDto.Price);

            if (productType.Price < minPrice) minPrice = productType.Price;
            
            if (productType.Price > maxPrice) maxPrice = productType.Price;
            
            foreach (var productImageDto in productTypeDto.Images)
                _productService.CreateProductImage(productType, productImageDto.Url);
        }

        product.SetPriceRange(minPrice, maxPrice);

        await _operationRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ProductDetailDto>(product);
    }
}