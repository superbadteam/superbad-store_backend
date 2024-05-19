using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using InventoryManagement.Core.Application.Products.CQRS.Queries.Requests;
using InventoryManagement.Core.Application.Products.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;
using InventoryManagement.Core.Domain.ProductAggregate.Specifications;

namespace InventoryManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class
    FilterAndPagingCurrentUserProductsQueryHandler : IQueryHandler<FilterAndPagingCurrentUserProductsQuery,
    FilterAndPagingResultDto<ProductSummaryDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<Product> _repository;

    public FilterAndPagingCurrentUserProductsQueryHandler(IReadOnlyRepository<Product> repository,
        ICurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<FilterAndPagingResultDto<ProductSummaryDto>> Handle(FilterAndPagingCurrentUserProductsQuery query,
        CancellationToken cancellationToken)
    {
        var productNamePartialMatchSpecification = new ProductNamePartialMatchSpecification(query.Dto.Keyword);

        var productUserIdSpecification = new ProductUserIdSpecification(_currentUser.Id);

        var productConditionSpecification = new ProductConditionSpecification(query.Dto.Condition);

        Specification<Product>? productCategorySpecifications = null;

        foreach (var categoryId in query.Dto.CategoryIds)
        {
            var productCategoryIdSpecification = new ProductCategoryIdSpecification(categoryId);

            var productParentCategoryIdSpecification = new ProductParentCategoryIdSpecification(categoryId);

            var categorySpecification = productCategoryIdSpecification.Or(productParentCategoryIdSpecification);

            productCategorySpecifications = productCategorySpecifications == null
                ? categorySpecification
                : productCategorySpecifications.Or(categorySpecification);
        }

        var specification = productNamePartialMatchSpecification.And(productConditionSpecification)
            .And(productUserIdSpecification);

        specification = productCategorySpecifications == null
            ? specification
            : specification.And(productCategorySpecifications);


        var (products, totalCount) = await _repository.GetFilterAndPagingAsync<ProductSummaryDto>(
            specification, query.Dto.Sort, query.Dto.PageIndex, query.Dto.PageSize);

        return new FilterAndPagingResultDto<ProductSummaryDto>(products, query.Dto.PageIndex, query.Dto.PageSize,
            totalCount);
    }
}