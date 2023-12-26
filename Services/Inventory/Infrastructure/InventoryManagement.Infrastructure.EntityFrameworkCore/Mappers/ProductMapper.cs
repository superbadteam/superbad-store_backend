using AutoMapper;
using InventoryManagement.Core.Application.Products.IntegrationEvents.Events;
using InventoryManagement.Core.Application.Products.ProductDTOs;
using InventoryManagement.Core.Domain.ProductAggregate.Entities;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductSummaryDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Images.Select(p => p.Url).FirstOrDefault()));
        CreateMap<Product, ProductDetailDto>();
        CreateMap<ProductType, ProductTypeDto>();
        CreateMap<ProductImage, ProductImageDto>();

        CreateMap<Product, ProductCreatedPayload>();
        CreateMap<ProductType, ProductTypePayload>();
        CreateMap<ProductImage, ProductImagePayload>();
    }
}