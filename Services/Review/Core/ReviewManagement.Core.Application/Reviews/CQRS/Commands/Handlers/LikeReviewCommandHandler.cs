using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Exceptions;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Handlers;

public class LikeReviewCommandHandler : ICommandHandler<LikeReviewCommand, ReviewDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;
    private readonly IReviewDomainService _reviewDomainService;
    private readonly IOperationRepository<Review> _reviewOperationRepository;
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LikeReviewCommandHandler(IReviewDomainService reviewDomainService, IUnitOfWork unitOfWork, IMapper mapper,
        IReadOnlyRepository<Review> reviewReadOnlyRepository, IOperationRepository<Review> reviewOperationRepository,
        ICurrentUser currentUser)
    {
        _reviewDomainService = reviewDomainService;
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
        _reviewOperationRepository = reviewOperationRepository;
        _currentUser = currentUser;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReviewDto> Handle(LikeReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await EntityHelper.GetOrThrowAsync(request.ReviewId, new ReviewNotFoundException(request.ReviewId),
            _reviewReadOnlyRepository);

        await _reviewDomainService.LikeAsync(review, _currentUser.Id);

        _reviewOperationRepository.Update(review);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ReviewDto>(review);
    }
}