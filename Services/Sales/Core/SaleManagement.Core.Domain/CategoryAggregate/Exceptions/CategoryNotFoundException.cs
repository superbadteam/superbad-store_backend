using BuildingBlock.Core.Domain.Exceptions;
using SaleManagement.Core.Domain.CategoryAggregate.Entities;

namespace SaleManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryNotFoundException : EntityNotFoundException
{
    public CategoryNotFoundException(Guid id) : base(nameof(Category), id)
    {
    }
}