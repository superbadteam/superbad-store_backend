using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using SaleManagement.Core.Application.Products.DTOs;

namespace SaleManagement.Core.Application.Products.CQRS.Queries.Requests;

public record FilterAndPagingProductsQuery
    (FilterAndPagingProductsDto Dto) : IQuery<FilterAndPagingResultDto<ProductSummaryDto>>;