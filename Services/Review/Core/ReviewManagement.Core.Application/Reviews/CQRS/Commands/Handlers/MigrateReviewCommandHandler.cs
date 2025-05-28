using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.IntegrationEvents.Events;
using ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Handlers;

public class MigrateReviewCommandHandler : ICommandHandler<MigrateReviewCommand>
{
    private readonly IEventBus _eventBus;
    private readonly IReviewDomainService _reviewDomainService;
    private readonly IOperationRepository<Review> _reviewOperationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MigrateReviewCommandHandler(IReviewDomainService reviewDomainService,
        IOperationRepository<Review> reviewOperationRepository, IEventBus eventBus, IUnitOfWork unitOfWork)
    {
        _reviewDomainService = reviewDomainService;
        _reviewOperationRepository = reviewOperationRepository;
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(MigrateReviewCommand request, CancellationToken cancellationToken)
    {
        var content = string.IsNullOrEmpty(request.Dto.Content) ? null : new Content(request.Dto.Content);

        var review = _reviewDomainService.Create(new Rating(request.Dto.Rating), content,
            request.Dto.ProductTypeId, request.Dto.UserId);

        await _reviewOperationRepository.AddAsync(review);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new ReviewCreatedIntegrationEvent(review.ProductTypeId, request.Dto.Rating));
    }
}