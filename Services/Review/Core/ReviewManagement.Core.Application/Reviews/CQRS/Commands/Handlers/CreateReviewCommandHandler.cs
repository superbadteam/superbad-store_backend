using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using ReviewManagement.Core.Application.Reviews.CQRS.Commands.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.DomainEvents.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Commands.Handlers;

public class CreateReviewCommandHandler : ICommandHandler<CreateReviewCommand, ReviewDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;
    private readonly IReviewDomainService _reviewDomainService;
    private readonly IOperationRepository<Review> _reviewOperationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IReviewDomainService reviewDomainService,
        IOperationRepository<Review> reviewOperationRepository, ICurrentUser currentUser)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _reviewDomainService = reviewDomainService;
        _reviewOperationRepository = reviewOperationRepository;
        _currentUser = currentUser;
    }

    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var content = string.IsNullOrEmpty(request.Dto.Content) ? null : new Content(request.Dto.Content);

        var review = await _reviewDomainService.CreateAsync(request.OrderItemId, new Rating(request.Dto.Rating),
            content, _currentUser.Id);

        await _reviewOperationRepository.AddAsync(review);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ReviewDto>(review);
    }
}