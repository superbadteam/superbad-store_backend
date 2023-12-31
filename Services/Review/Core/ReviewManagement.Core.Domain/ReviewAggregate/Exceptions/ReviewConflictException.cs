using BuildingBlock.Core.Domain.Exceptions;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Exceptions;

public class ReviewConflictException : EntityConflictException
{
    public ReviewConflictException(Guid productId, Guid userId) : base(
        $"User with id: {userId} already reviewed for product with id: {productId}")
    {
    }
}