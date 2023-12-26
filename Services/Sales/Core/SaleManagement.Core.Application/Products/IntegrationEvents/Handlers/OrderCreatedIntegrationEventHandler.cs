using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Application.Products.IntegrationEvents.Events;
using SaleManagement.Core.Domain.ProductAggregate.DomainServices;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Exceptions;

namespace SaleManagement.Core.Application.Products.IntegrationEvents.Handlers;

public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
{
    private readonly IProductDomainService _productDomainService;
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreatedIntegrationEventHandler(IProductDomainService productDomainService,
        IOperationRepository<Product> productOperationRepository, IUnitOfWork unitOfWork,
        IReadOnlyRepository<ProductType> productTypeReadOnlyRepository)
    {
        _productDomainService = productDomainService;
        _productOperationRepository = productOperationRepository;
        _unitOfWork = unitOfWork;
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
    }

    public async Task HandleAsync(OrderCreatedIntegrationEvent @event)
    {
        var productDictionary = new Dictionary<Guid, Product>();

        foreach (var item in @event.Items)
        {
            var specification = new EntityIdSpecification<ProductType>(item.ProductTypeId);

            var productType = Optional<ProductType>
                .Of(await _productTypeReadOnlyRepository.GetAnyAsync(specification, "Product"))
                .ThrowIfNotExist(new ProductTypeNotFoundException(item.ProductTypeId)).Get();

            if (productDictionary.TryGetValue(productType.Product.Id, out var product))
            {
                product.Types.Add(productType);

                _productDomainService.IncreaseSold(product, item.ProductTypeId, item.Quantity);
            }
            else
            {
                _productDomainService.IncreaseSold(productType.Product, item.ProductTypeId, item.Quantity);

                productDictionary.Add(productType.Product.Id, productType.Product);
            }
        }

        foreach (var productPair in productDictionary) _productOperationRepository.Update(productPair.Value);

        await _unitOfWork.SaveChangesAsync();
    }
}