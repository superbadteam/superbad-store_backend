using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using ReviewManagement.Core.Application.Reviews.DTOs;

namespace ReviewManagement.Core.Application.Reviews.CQRS.Queries.Requests;

public record FilterAndPagingProductReviewsQuery(Guid ProductId, FilterAndPagingProductReviewsDto Dto)
    : IQuery<FilterAndPagingResultDto<ReviewDto>>;