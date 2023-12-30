using AutoMapper;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.Mapper;

public class ReviewMapper : Profile
{
    public ReviewMapper()
    {
        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.Value))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content!.Value))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.ProductType));

        CreateMap<ProductType, ReviewedProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Name));
    }
}