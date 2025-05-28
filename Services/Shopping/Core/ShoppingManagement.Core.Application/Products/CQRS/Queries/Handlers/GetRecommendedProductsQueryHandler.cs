using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetRecommendedProductsQueryHandler : IQueryHandler<GetRecommendedProductsQuery, List<ProductSummaryDto>>
{
    
    public Task<List<ProductSummaryDto>> Handle(GetRecommendedProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}