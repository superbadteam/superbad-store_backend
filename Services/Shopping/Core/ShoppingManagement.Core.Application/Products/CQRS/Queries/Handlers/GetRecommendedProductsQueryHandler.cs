using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetRecommendedProductsQueryHandler : IQueryHandler<GetRecommendedProductsQuery, List<ProductSummaryDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;
    private readonly IRecommendationService _recommendationService;

    public GetRecommendedProductsQueryHandler(IRecommendationService recommendationService, ICurrentUser currentUser,
        IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _recommendationService = recommendationService;
        _currentUser = currentUser;
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<List<ProductSummaryDto>> Handle(GetRecommendedProductsQuery request,
        CancellationToken cancellationToken)
    {
        var productIds = (await _recommendationService.GetRecommendedProductIds(_currentUser.Id)).ToList();

        var products =
            await _productReadOnlyRepository.GetAllAsync<ProductSummaryDto>(new ProductIdSpecification(productIds));

        return products.OrderBy(p => productIds.IndexOf(p.Id)).ToList();
    }
}