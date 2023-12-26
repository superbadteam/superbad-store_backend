using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Exceptions;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

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