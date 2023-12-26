using BuildingBlock.Core.Domain.Exceptions;
using ShoppingManagement.Core.Domain.CategoryAggregate.Entities;

namespace ShoppingManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryNotFoundException : EntityNotFoundException
{
    public CategoryNotFoundException(Guid id) : base(nameof(Category), id)
    {
    }
}