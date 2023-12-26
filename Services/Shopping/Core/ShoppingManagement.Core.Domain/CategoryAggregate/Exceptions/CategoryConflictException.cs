using BuildingBlock.Core.Domain.Exceptions;

namespace ShoppingManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryConflictException : EntityConflictException
{
    public CategoryConflictException(Guid id) : base(id)
    {
    }
}