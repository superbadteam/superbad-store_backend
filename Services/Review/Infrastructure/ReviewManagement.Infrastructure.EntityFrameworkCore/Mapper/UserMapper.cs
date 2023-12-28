using AutoMapper;
using ReviewManagement.Core.Application.Users.DTOs;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, SellerDto>();
    }
}