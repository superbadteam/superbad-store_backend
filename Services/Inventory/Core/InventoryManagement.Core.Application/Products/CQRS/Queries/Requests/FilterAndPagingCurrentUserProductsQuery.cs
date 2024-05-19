using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Queries.Requests;

public record FilterAndPagingCurrentUserProductsQuery(FilterAndPagingCurrentUserProductsDto Dto)
    : IQuery<FilterAndPagingResultDto<ProductSummaryDto>>;