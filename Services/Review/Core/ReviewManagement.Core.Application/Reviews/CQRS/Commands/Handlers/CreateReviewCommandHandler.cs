using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Handlers;

public class CreateReviewCommandHandler : ICommandHandler<CreateReviewCommand, ReviewDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReviewDomainService _reviewDomainService;
    private readonly IOperationRepository<Review> _reviewOperationRepository;
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IReviewDomainService reviewDomainService,
        IOperationRepository<Review> reviewOperationRepository, ICurrentUser currentUser,
        IReadOnlyRepository<Review> reviewReadOnlyRepository)
    {
        _unitOfWork = unitOfWork;
        _reviewDomainService = reviewDomainService;
        _reviewOperationRepository = reviewOperationRepository;
        _currentUser = currentUser;
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
    }

    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var content = string.IsNullOrEmpty(request.Dto.Content) ? null : new Content(request.Dto.Content);

        var review = await _reviewDomainService.CreateAsync(request.OrderItemId, new Rating(request.Dto.Rating),
            content, _currentUser.Id);

        await _reviewOperationRepository.AddAsync(review);

        await _unitOfWork.SaveChangesAsync();

        return Optional<ReviewDto>
            .Of(await _reviewReadOnlyRepository.GetAnyAsync<ReviewDto>(new EntityIdSpecification<Review>(review.Id)))
            .Get();
    }
}