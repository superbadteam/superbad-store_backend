using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using ShoppingManagement.Core.Application.Products.DTOs;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;

public record FilterAndPagingProductsQuery(FilterAndPagingProductsDto Dto)
    : IQuery<FilterAndPagingResultDto<ProductSummaryDto>>;