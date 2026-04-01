using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.ProductAggregate.DomainServices;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Exceptions;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Handlers;

public class ProductEditedIntegrationEventHandler : IIntegrationEventHandler<ProductEditedIntegrationEvent>
{
    private readonly IProductDomainService _productDomainService;
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public ProductEditedIntegrationEventHandler(IOperationRepository<Product> productOperationRepository,
        IProductDomainService productDomainService, IUnitOfWork unitOfWork, IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _productOperationRepository = productOperationRepository;
        _productDomainService = productDomainService;
        _unitOfWork = unitOfWork;
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task HandleAsync(ProductEditedIntegrationEvent @event)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(@event.ProductId);
        var product = await _productReadOnlyRepository.GetAnyAsync(productIdSpecification, "Types", false, true) ?? throw new ProductNotFoundException(@event.ProductId);

        foreach (var productType in product.Types)
        {
            productType.Quantity = 10000;
        }

        await _unitOfWork.SaveChangesAsync();
    }
}