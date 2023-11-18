using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ProductManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;
using ProductManagement.Core.Application.DTOs.ProductDTOs;
using ProductManagement.Core.Domain.ProductAggregate.Entities;
using ProductManagement.Core.Domain.ProductAggregate.Exceptions;

namespace ProductManagement.Core.Application.CQRS.Queries.ProductQueries.Handlers;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailDto>
{
    private readonly IReadOnlyRepository<Product> _repository;

    public GetProductQueryHandler(IReadOnlyRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<ProductDetailDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(query.ProductId);
        var product = Optional<ProductDetailDto>
            .Of(await _repository.GetAnyAsync<ProductDetailDto>(productIdSpecification))
            .ThrowIfNotExist(new ProductNotFoundException(query.ProductId)).Get();

        return product;
    }
}