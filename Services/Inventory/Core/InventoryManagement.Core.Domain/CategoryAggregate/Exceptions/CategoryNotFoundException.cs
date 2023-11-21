using BuildingBlock.Core.Domain.Exceptions;
using InventoryManagement.Core.Domain.CategoryAggregate.Entities;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryNotFoundException : EntityNotFoundException
{
    public CategoryNotFoundException(Guid id) : base(nameof(Category), id)
    {
    }
}