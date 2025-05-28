using BuildingBlock.Core.Domain.Exceptions;

namespace InventoryManagement.Core.Domain.CategoryAggregate.Exceptions;

public class CategoryConflictException : EntityConflictException
{
    public CategoryConflictException(string entity, string column, object value) : base(entity, column, value)
    {
    }

    public CategoryConflictException(string message) : base(message)
    {
    }

    public CategoryConflictException(string entity, Guid id) : base(entity, id)
    {
    }

    public CategoryConflictException(Guid id) : base(id)
    {
    }
}