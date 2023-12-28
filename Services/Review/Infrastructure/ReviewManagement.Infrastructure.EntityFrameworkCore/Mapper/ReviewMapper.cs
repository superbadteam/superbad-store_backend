using AutoMapper;
using ReviewManagement.Core.Application.Reviews.DTOs;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Infrastructure.EntityFrameworkCore.Mapper;

public class ReviewMapper : Profile
{
    public ReviewMapper()
    {
        CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.Value))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content!.Value));
    }
}