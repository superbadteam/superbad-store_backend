using AutoMapper;
using IdentityManagement.Core.Application.DTOs.UserDTOs;
using IdentityManagement.Core.Domain.UserAggregate.Entities;
using IdentityManagement.Infrastructure.Identity.UserAggregate.Entities;

namespace IdentityManagement.Infrastructure.EntityFrameworkCore.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<ApplicationRefreshToken, RefreshToken>();
        CreateMap<RefreshToken, ApplicationRefreshToken>();

        CreateMap<User, ApplicationUser>()
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper()));
        CreateMap<User, UserDetailDto>();
        CreateMap<User, UserSummaryDto>();

        CreateMap<ApplicationUser, UserSummaryDto>();
        CreateMap<ApplicationUser, UserCreationDto>();
        CreateMap<ApplicationUser, User>();

        CreateMap<UserCreationDto, UserDetailDto>();
    }
}