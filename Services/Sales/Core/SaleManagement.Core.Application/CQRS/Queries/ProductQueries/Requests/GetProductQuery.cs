using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.DTOs.ProductDTOs;

namespace SaleManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;

public record GetProductQuery(Guid ProductId) : IQuery<ProductDetailDto>;