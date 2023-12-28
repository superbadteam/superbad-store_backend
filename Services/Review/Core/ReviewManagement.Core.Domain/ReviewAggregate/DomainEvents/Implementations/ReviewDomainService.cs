using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;
using ReviewManagement.Core.Domain.OrderAggregate.Exceptions;
using ReviewManagement.Core.Domain.OrderAggregate.Specifications;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Exceptions;
using ReviewManagement.Core.Domain.ReviewAggregate.Specifications;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Implementations;

public class ReviewDomainService : IReviewDomainService
{
    private readonly IReadOnlyRepository<OrderItem> _orderItemReadOnlyRepository;
    private readonly IReadOnlyRepository<ProductType> _productTypeReadOnlyRepository;
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;

    public ReviewDomainService(IReadOnlyRepository<Review> reviewReadOnlyRepository,
        IReadOnlyRepository<ProductType> productTypeReadOnlyRepository,
        IReadOnlyRepository<OrderItem> orderItemReadOnlyRepository)
    {
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
        _productTypeReadOnlyRepository = productTypeReadOnlyRepository;
        _orderItemReadOnlyRepository = orderItemReadOnlyRepository;
    }

    public async Task<Review> CreateAsync(Guid orderItemId, Rating rating, Content? content, Guid userId)
    {
        var orderItem = await CheckValidOnCreateAsync(orderItemId, userId);

        return new Review(orderItem.ProductTypeId, rating, content, userId);
    }

    private async Task<OrderItem> CheckValidOnCreateAsync(Guid orderItemId, Guid userId)
    {
        var orderItemUserIdSpecification = new OrderItemUserIdSpecification(userId);
        var orderItemIdSpecification = new EntityIdSpecification<OrderItem>(orderItemId);
        var orderItemSpecification = orderItemUserIdSpecification.And(orderItemIdSpecification);

        var orderItem = Optional<OrderItem>
            .Of(await _orderItemReadOnlyRepository.GetAnyAsync(orderItemSpecification, "ProductType"))
            .ThrowIfNotExist(new OrderItemNotFoundException(orderItemId, userId)).Get();

        var reviewProductIdSpecification = new ReviewProductIdSpecification(orderItem.ProductType.ProductId);
        var reviewUserIdSpecification = new ReviewUserIdSpecification(userId);

        var specification = reviewProductIdSpecification.And(reviewUserIdSpecification);

        await EntityHelper.ThrowIfExistAsync(specification,
            new ReviewConflictException(orderItem.ProductType.ProductId, userId),
            _reviewReadOnlyRepository);

        return orderItem;
    }
}