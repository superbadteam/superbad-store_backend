using AutoMapper;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;
using InventoryManagement.Core.Application.Products.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Specifications;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Handlers;

public class SyncProductsAmongServicesCommandHandler : ICommandHandler<SyncProductsAmongServicesCommand>
{
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<ProductImage> _productImageReadOnlyRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<Product> _readOnlyRepository;

    public SyncProductsAmongServicesCommandHandler(IEventBus eventBus, IReadOnlyRepository<Product> readOnlyRepository,
        IMapper mapper, IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<ProductImage> productImageReadOnlyRepository)
    {
        _eventBus = eventBus;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _productImageReadOnlyRepository = productImageReadOnlyRepository;
    }

    public async Task Handle(SyncProductsAmongServicesCommand request, CancellationToken cancellationToken)
    {
        var products = await _readOnlyRepository.GetAllAsync();

        foreach (var product in products)
        {
            var productTypes = await
                _productTypeReadOnlyRepository.GetAllAsync(new ProductTypeProductIdSpecification(product.Id));

            var productImages = await
                _productImageReadOnlyRepository.GetAllAsync(new ProductImageProductIdSpecification(product.Id));

            product.Types = productTypes;
            product.Images = productImages;

            _eventBus.Publish(new ProductCreatedIntegrationEvent(_mapper.Map<ProductCreatedPayload>(product)));
        }
    }
}