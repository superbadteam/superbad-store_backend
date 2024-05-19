using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Application.Products.CQRS.Queries.Requests;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

namespace ShoppingManagement.Core.Application.Products.CQRS.Queries.Handlers;

public class
    FilterAndPagingProductsQueryHandler : IQueryHandler<FilterAndPagingProductsQuery,
    FilterAndPagingResultDto<ProductSummaryDto>>
{
    private readonly IReadOnlyRepository<Product> _repository;

    public FilterAndPagingProductsQueryHandler(IReadOnlyRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<FilterAndPagingResultDto<ProductSummaryDto>> Handle(FilterAndPagingProductsQuery query,
        CancellationToken cancellationToken)
    {
        var productNamePartialMatchSpecification = new ProductNamePartialMatchSpecification(query.Dto.Keyword);

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

        var specification = productNamePartialMatchSpecification.And(productConditionSpecification);

        specification = productCategorySpecifications == null
            ? specification
            : specification.And(productCategorySpecifications);


        var (products, totalCount) = await _repository.GetFilterAndPagingAsync<ProductSummaryDto>(
            specification, query.Dto.Sort, query.Dto.PageIndex, query.Dto.PageSize);

        return new FilterAndPagingResultDto<ProductSummaryDto>(products, query.Dto.PageIndex, query.Dto.PageSize,
            totalCount);
    }
}