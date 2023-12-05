using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.DTOs;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using SaleManagement.Core.Application.CQRS.Queries.ProductQueries.Requests;
using SaleManagement.Core.Application.DTOs.ProductDTOs;
using SaleManagement.Core.Domain.ProductAggregate.Entities;
using SaleManagement.Core.Domain.ProductAggregate.Specifications;

namespace SaleManagement.Core.Application.CQRS.Queries.ProductQueries.Handlers;

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
            var categorySpecification = new ProductCategoryIdSpecification(categoryId);
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