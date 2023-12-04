using BuildingBlock.Core.Domain.Exceptions;

namespace SaleManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryConflictException : EntityConflictException
{
    public CategoryConflictException(Guid id) : base(id)
    {
    }
}