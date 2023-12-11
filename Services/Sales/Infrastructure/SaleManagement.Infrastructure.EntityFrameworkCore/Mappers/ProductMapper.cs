using AutoMapper;
using SaleManagement.Core.Application.DTOs.ProductDTOs;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductSummaryDto>();
        CreateMap<Product, ProductDetailDto>();

        CreateMap<ProductType, ProductTypeDto>();
        CreateMap<ProductImage, ProductImageDto>();
    }
}