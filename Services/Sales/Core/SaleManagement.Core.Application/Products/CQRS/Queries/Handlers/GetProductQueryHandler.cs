using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using SaleManagement.Core.Application.Products.CQRS.Queries.Requests;
using SaleManagement.Core.Application.Products.DTOs;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Exceptions;

namespace SaleManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailDto>
{
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public GetProductQueryHandler(IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<ProductDetailDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(request.ProductId);

        return Optional<ProductDetailDto>
            .Of(await _productReadOnlyRepository.GetAnyAsync<ProductDetailDto>(productIdSpecification))
            .ThrowIfNotExist(new ProductNotFoundException(request.ProductId)).Get();
    }
}