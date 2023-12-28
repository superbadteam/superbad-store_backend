using BuildingBlock.Core.Domain;
using ReviewManagement.Core.Domain.ProductAggregate.Entities;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Entities;

public class Review : AggregateRoot
{
    public Review()
    {
        Likes = 0;
        Replies = new List<Review>();
    }

    public Review(Guid productTypeId, Rating rating, Content? content, Guid userId) : this()
    {
        ProductTypeId = productTypeId;
        Rating = rating;
        Content = content;
        UserId = userId;
    }

    public Content? Content { get; set; }

    public Guid ProductTypeId { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Rating Rating { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public Review? Parent { get; set; }

    public List<Review> Replies { get; set; }

    public int Likes { get; set; }
}