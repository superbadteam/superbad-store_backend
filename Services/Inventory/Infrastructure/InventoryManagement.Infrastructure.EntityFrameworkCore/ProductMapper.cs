using AutoMapper;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore;

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