using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using OrderManagement.Core.Application.Products.IntegrationEvents.Events;
using OrderManagement.Core.Domain.ProductAggregate.DomainServices;
using OrderManagement.Core.Domain.ProductAggregate.Entities;

namespace OrderManagement.Core.Application.Products.IntegrationEvents.Handlers;

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
            @event.Product.Name, @event.Product.Condition, @event.Product.Images.First().Url, @event.Product.CreatedAt,
            @event.Product.CreatedBy);

        foreach (var productTypePayload in @event.Product.Types)
            _productDomainService.CreateProductType(product, productTypePayload.Id,
                productTypePayload.Name, productTypePayload.Quantity, productTypePayload.Price,
                productTypePayload.ImageUrl, productTypePayload.CreatedAt, productTypePayload.CreatedBy);

        await _productOperationRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();
    }
}