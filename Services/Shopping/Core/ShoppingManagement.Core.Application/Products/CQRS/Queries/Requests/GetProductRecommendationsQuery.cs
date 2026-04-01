using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Products.DTOs;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;

public sealed record GetProductRecommendationsQuery(Guid ProductId) : IQuery<List<ProductSummaryDto>>;