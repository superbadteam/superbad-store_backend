using BuildingBlock.Core.Domain.Exceptions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Exceptions;

public class ReviewNotFoundException : EntityNotFoundException
{
    public ReviewNotFoundException(Guid id) : base(nameof(Review), id)
    {
    }
}