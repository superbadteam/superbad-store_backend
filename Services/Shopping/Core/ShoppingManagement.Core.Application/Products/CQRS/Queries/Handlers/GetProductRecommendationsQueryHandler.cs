using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetProductRecommendationsQueryHandler : IQueryHandler<GetProductRecommendationsQuery, List<ProductSummaryDto>>
{
    private readonly IRecommendationService _recommendationService;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public GetProductRecommendationsQueryHandler(IRecommendationService recommendationService, IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _recommendationService = recommendationService;
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<List<ProductSummaryDto>> Handle(GetProductRecommendationsQuery request, CancellationToken cancellationToken)
    {
        var productIds = (await _recommendationService.GetProductRecommendations(request.ProductId)).ToList();  
        
        var products =
            await _productReadOnlyRepository.GetAllAsync<ProductSummaryDto>(new ProductIdSpecification(productIds));

        return products.OrderBy(p => productIds.IndexOf(p.Id)).ToList();
    }
}