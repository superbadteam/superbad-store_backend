using AutoMapper;
using OrderManagement.Core.Application.Locations.DTOs;
using OrderManagement.Core.Domain.LocationAggregate.Entities;

namespace OrderManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class LocationMapper : Profile
{
    public LocationMapper()
    {
        CreateMap<Location, CityDto>()
            .ForMember(dest => dest.Districts, opt => opt.MapFrom(src => src.SubLocations));
        CreateMap<Location, DistrictDto>();
    }
}