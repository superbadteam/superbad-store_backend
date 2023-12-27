using AutoMapper;
using OrderManagement.Core.Application.Users.DTOs;
using OrderManagement.Core.Domain.UserAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<ShippingAddress, ShippingAddressDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.District.ParentLocation.Name))
            .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District.Name))
            .ForMember(dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => $"+{src.PhoneNumber.CountryCode}{src.PhoneNumber.NationalNumber}"));

        CreateMap<User, SellerDto>();
    }
}