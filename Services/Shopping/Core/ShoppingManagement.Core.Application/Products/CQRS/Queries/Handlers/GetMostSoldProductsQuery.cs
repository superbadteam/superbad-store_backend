using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetMostSoldProductsQueryHandler : IQueryHandler<GetMostSoldProductsQuery, List<ProductSummaryDto>>
{
    private readonly IReadOnlyRepository<Product> _productRepository;

    public GetMostSoldProductsQueryHandler(IReadOnlyRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductSummaryDto>> Handle(GetMostSoldProductsQuery request,
        CancellationToken cancellationToken)
    {
        var (products, _) =
            await _productRepository.GetFilterAndPagingAsync<ProductSummaryDto>(null, "Sold DESC", 1, 10);

        return products;
    }
}