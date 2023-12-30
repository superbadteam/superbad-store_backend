using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using ReviewManagement.Core.Application.Reviews.CQRS.Queries.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Queries.Handlers;

public class FilterAndPagingCurrentUserReviewsQueryHandler : IQueryHandler<FilterAndPagingCurrentUserReviewsQuery,
    FilterAndPagingResultDto<ReviewDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;

    public FilterAndPagingCurrentUserReviewsQueryHandler(IReadOnlyRepository<Review> reviewReadOnlyRepository,
        ICurrentUser currentUser)
    {
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<FilterAndPagingResultDto<ReviewDto>> Handle(FilterAndPagingCurrentUserReviewsQuery request,
        CancellationToken cancellationToken)
    {
        var specification = new ReviewUserIdSpecification(_currentUser.Id);

        var (reviews, totalCount) = await _reviewReadOnlyRepository.GetFilterAndPagingAsync<ReviewDto>(specification,
            request.Dto.Sort, request.Dto.PageIndex, request.Dto.PageSize);

        return new FilterAndPagingResultDto<ReviewDto>(reviews, request.Dto.PageIndex, request.Dto.PageSize,
            totalCount);
    }
}