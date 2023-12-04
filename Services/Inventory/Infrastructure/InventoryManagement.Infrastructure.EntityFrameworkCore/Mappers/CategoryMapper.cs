using AutoMapper;
using InventoryManagement.Core.Application.DTOs.CategoryDTOs;
using InventoryManagement.Core.Application.IntegrationEvents.CategoryIntegrationEvents.Events;
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