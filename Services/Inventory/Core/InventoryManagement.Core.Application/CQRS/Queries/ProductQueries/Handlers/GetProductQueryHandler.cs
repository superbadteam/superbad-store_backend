using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Exceptions;

namespace InventoryManagement.Core.Application.CQRS.Queries.ProductQueries.Handlers;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailDto>
{
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public GetProductQueryHandler(IReadOnlyRepository<Product> productReadOnlyRepository)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
    }

    public async Task<ProductDetailDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(query.ProductId);

        return Optional<ProductDetailDto>
            .Of(await _productReadOnlyRepository.GetAnyAsync<ProductDetailDto>(productIdSpecification))
            .ThrowIfNotExist(new ProductNotFoundException(query.ProductId)).Get();
    }
}