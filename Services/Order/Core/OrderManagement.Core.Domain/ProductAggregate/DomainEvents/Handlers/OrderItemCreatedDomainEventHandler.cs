using BuildingBlock.Core.Domain.DomainEvents;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.OrderAggregate.DomainEvents.Events;
using OrderManagement.Core.Domain.ProductAggregate.DomainServices;
using OrderManagement.Core.Domain.ProductAggregate.Entities;
using OrderManagement.Core.Domain.ProductAggregate.Exceptions;

namespace OrderManagement.Core.Domain.ProductAggregate.DomainEvents.Handlers;

public class OrderItemCreatedDomainEventHandler : IDomainEventHandler<OrderItemCreatedDomainEvent>
{
    private readonly IProductDomainService _productDomainService;
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;

    public OrderItemCreatedDomainEventHandler(IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IProductDomainService productDomainService, IOperationRepository<Product> productOperationRepository)
    {
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _productDomainService = productDomainService;
        _productOperationRepository = productOperationRepository;
    }

    public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var productDictionary = new Dictionary<Guid, Product>();

        foreach (var item in notification.Items)
        {
            var specification = new EntityIdSpecification<ProductType>(item.ProductTypeId);

            var productType = Optional<ProductType>
                .Of(await _productTypeReadOnlyRepository.GetAnyAsync(specification, "Product"))
                .ThrowIfNotExist(new ProductTypeNotFoundException(item.ProductTypeId)).Get();

            _productDomainService.Sell(productType.Product, item.ProductTypeId, item.Quantity);

            if (productDictionary.TryGetValue(productType.Product.Id, out var product))
                product.Types.Add(productType);
            else
                productDictionary.Add(productType.Product.Id, productType.Product);
        }

        foreach (var productPair in productDictionary) _productOperationRepository.Update(productPair.Value);
    }
}