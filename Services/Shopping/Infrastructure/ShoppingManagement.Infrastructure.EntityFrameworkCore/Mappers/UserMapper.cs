using AutoMapper;
using ShoppingManagement.Core.Application.Users.DTOs;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, CartDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Carts));
        CreateMap<User, UserDto>();
        CreateMap<Cart, CartItemDto>();
        CreateMap<ProductType, ProductTypeCartDto>();
        CreateMap<Product, ProductCartDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Images.Select(p => p.Url).FirstOrDefault()));
    }
}