using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.OrderAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.UserAggregate.Entities;

public sealed class User : AggregateRoot
{
    public User()
    {
        Reviews = new List<Review>();
        OrderItems = new List<OrderItem>();
        LikedReviews = new List<LikedReview>();
    }

    public User(DateTime createdAt, string createdBy) : this()
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public User(Guid id, string name, string? avatarUrl, DateTime createdAt, string createdBy) : this(
        createdAt, createdBy)
    {
        Id = id;
        Name = name;
        AvatarUrl = avatarUrl;
    }

    public string Name { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public List<Review> Reviews { get; set; }

    public List<OrderItem> OrderItems { get; set; }

    public List<LikedReview> LikedReviews { get; set; }
}