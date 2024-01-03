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
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src =>
                    src.Carts.Where(cart => cart.DeletedAt == null && cart.ProductType.DeletedAt == null)
                        .Sum(cart => cart.ProductType.Price * cart.Quantity)))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Carts.Where(cart => cart.DeletedAt == null)));
        CreateMap<User, UserDto>();
        CreateMap<Cart, CartItemDto>();
        CreateMap<ProductType, ProductTypeCartDto>();
        CreateMap<Product, ProductCartDto>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Images.Select(p => p.Url).FirstOrDefault()));
    }
}