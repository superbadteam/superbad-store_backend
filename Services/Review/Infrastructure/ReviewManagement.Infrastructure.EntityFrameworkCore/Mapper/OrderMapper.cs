using AutoMapper;
using ReviewManagement.Core.Application.Orders.DTOs;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.Mapper;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => src.ProductType.Price))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductType.Product.Name))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductType.Product.Id))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ProductType.Product.ImageUrl))
            .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.ProductType.Product.User));
    }
}