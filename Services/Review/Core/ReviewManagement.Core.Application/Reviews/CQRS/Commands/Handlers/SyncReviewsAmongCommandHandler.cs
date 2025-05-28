using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.IntegrationEvents.Events;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Handlers;

public class SyncReviewsAmongCommandHandler : ICommandHandler<SyncReviewsAmongServicesCommand>
{
    private readonly IEventBus _eventBus;
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;

    public SyncReviewsAmongCommandHandler(IEventBus eventBus, IReadOnlyRepository<Review> reviewReadOnlyRepository)
    {
        _eventBus = eventBus;
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
    }

    public async Task Handle(SyncReviewsAmongServicesCommand request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewReadOnlyRepository.GetAllAsync();

        foreach (var review in reviews)
            _eventBus.Publish(new ReviewCreatedIntegrationEvent(review.ProductTypeId, review.Rating.Value));
    }
}