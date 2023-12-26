using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using SaleManagement.Core.Application.Products.IntegrationEvents.Events;
using SaleManagement.Core.Domain.ProductAggregate.DomainServices;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Application.Products.IntegrationEvents.Handlers;

public class ProductCreatedIntegrationEventHandler : IIntegrationEventHandler<ProductCreatedIntegrationEvent>
{
    private readonly IProductDomainService _productDomainService;
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductCreatedIntegrationEventHandler(IOperationRepository<Product> productOperationRepository,
        IUnitOfWork unitOfWork, IProductDomainService productDomainService)
    {
        _productOperationRepository = productOperationRepository;
        _unitOfWork = unitOfWork;
        _productDomainService = productDomainService;
    }

    public async Task HandleAsync(ProductCreatedIntegrationEvent @event)
    {
        var product = await _productDomainService.CreateAsync(@event.Product.Id, @event.Product.UserId,
            @event.Product.Name, @event.Product.Description, @event.Product.CategoryId, @event.Product.Condition,
            @event.Product.CreatedAt, @event.Product.CreatedBy);

        var minPrice = double.MaxValue;
        var maxPrice = double.MinValue;

        foreach (var productTypePayload in @event.Product.Types)
        {
            var productType = _productDomainService.CreateProductType(product, productTypePayload.Id,
                productTypePayload.Name, productTypePayload.Quantity, productTypePayload.Price,
                productTypePayload.ImageUrl, productTypePayload.CreatedAt, productTypePayload.CreatedBy);

            if (productType.Price < minPrice) minPrice = productType.Price;

            if (productType.Price > maxPrice) maxPrice = productType.Price;
        }

        foreach (var productImagePayload in @event.Product.Images)
            _productDomainService.CreateProductImage(product, productImagePayload.Id, productImagePayload.Url,
                productImagePayload.CreatedAt, productImagePayload.CreatedBy);

        product.SetPriceRange(minPrice, maxPrice);

        await _productOperationRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();
    }
}