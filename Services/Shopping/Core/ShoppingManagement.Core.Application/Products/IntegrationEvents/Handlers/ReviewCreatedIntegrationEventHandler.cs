using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.ProductAggregate.DomainServices;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Exceptions;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Handlers;

public class ReviewCreatedIntegrationEventHandler : IIntegrationEventHandler<ReviewCreatedIntegrationEvent>
{
    private readonly IProductDomainService _productDomainService;
    private readonly IOperationRepository<Product> _productOperationRepository;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewCreatedIntegrationEventHandler(IReadOnlyRepository<Product> productReadOnlyRepository,
        IOperationRepository<Product> productOperationRepository, IProductDomainService productDomainService,
        IUnitOfWork unitOfWork)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _productOperationRepository = productOperationRepository;
        _productDomainService = productDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(ReviewCreatedIntegrationEvent @event)
    {
        var product = await EntityHelper.GetOrThrowAsync(@event.ProductId,
            new ProductNotFoundException(@event.ProductId), _productReadOnlyRepository);

        _productDomainService.AddRating(product, @event.Rating);

        _productOperationRepository.Update(product);

        await _unitOfWork.SaveChangesAsync();
    }
}