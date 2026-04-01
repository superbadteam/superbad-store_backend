using BuildingBlock.Core.Domain;

namespace ShoppingManagement.Core.Domain.UserAggregate.Entities;

public class UserIdMap : AggregateRoot
{
    public Guid GuidUserId { get; set; }
    public string StringUserId { get; set; } = null!;
}