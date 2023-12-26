using AutoMapper;
using InventoryManagement.Core.Application.Categories.DTOs;
using InventoryManagement.Core.Application.Categories.IntegrationEvents.Events;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Infrastructure.EntityFrameworkCore.Mappers;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<Category, CategoryCreatedPayload>();
    }
}