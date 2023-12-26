using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using InventoryManagement.Core.Application.Products.CQRS.Queries.Requests;
using InventoryManagement.Core.Application.Products.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Exceptions;
using InventoryManagement.Core.Domain.ProductAggregate.Specifications;

namespace InventoryManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class GetCurrentUserProductQueryHandler : IQueryHandler<GetCurrentUserProductQuery, ProductDetailDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Product> _productReadOnlyRepository;

    public GetCurrentUserProductQueryHandler(IReadOnlyRepository<Product> productReadOnlyRepository,
        ICurrentUser currentUser)
    {
        _productReadOnlyRepository = productReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<ProductDetailDto> Handle(GetCurrentUserProductQuery query, CancellationToken cancellationToken)
    {
        var productIdSpecification = new EntityIdSpecification<Product>(query.ProductId);

        var productUserIdSpecification = new ProductUserIdSpecification(_currentUser.Id);

        var specification = productIdSpecification.And(productUserIdSpecification);

        return Optional<ProductDetailDto>
            .Of(await _productReadOnlyRepository.GetAnyAsync<ProductDetailDto>(specification))
            .ThrowIfNotExist(new ProductNotFoundException(query.ProductId)).Get();
    }
}