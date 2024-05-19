using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using ReviewManagement.Core.Application.Reviews.CQRS.Queries.Requests;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Queries.Handlers;

public class
    FilterAndPagingProductReviewsQueryHandler : IQueryHandler<FilterAndPagingProductReviewsQuery,
    FilterAndPagingResultDto<ReviewDto>>
{
    private readonly IReadOnlyRepository<Review> _reviewReadOnlyRepository;

    public FilterAndPagingProductReviewsQueryHandler(IReadOnlyRepository<Review> reviewReadOnlyRepository)
    {
        _reviewReadOnlyRepository = reviewReadOnlyRepository;
    }

    public async Task<FilterAndPagingResultDto<ReviewDto>> Handle(FilterAndPagingProductReviewsQuery request,
        CancellationToken cancellationToken)
    {
        var reviewContentPartialMatchSpecification = new ReviewContentPartialMatchSpecification(request.Dto.Keyword);

        var reviewProductIdSpecification = new ReviewProductIdSpecification(request.ProductId);

        var specification = reviewContentPartialMatchSpecification.And(reviewProductIdSpecification);

        var (reviews, totalCount) = await _reviewReadOnlyRepository.GetFilterAndPagingAsync<ReviewDto>(specification,
            request.Dto.Sort, request.Dto.PageIndex, request.Dto.PageSize);

        return new FilterAndPagingResultDto<ReviewDto>(reviews, request.Dto.PageIndex, request.Dto.PageSize,
            totalCount);
    }
}