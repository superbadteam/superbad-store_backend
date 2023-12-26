using AutoMapper;
using ShoppingManagement.Core.Application.Products.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Mappers;

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