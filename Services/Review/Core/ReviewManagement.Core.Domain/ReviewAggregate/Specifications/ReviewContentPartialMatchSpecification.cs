using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ReviewManagement.Core.Domain.ReviewAggregate.Entities;

namespace ReviewManagement.Core.Domain.ReviewAggregate.Specifications;

public class ReviewContentPartialMatchSpecification : Specification<Review>
{
    private readonly string _keyword;

    public ReviewContentPartialMatchSpecification(string keyword)
    {
        _keyword = keyword;
    }

    public override Expression<Func<Review, bool>> ToExpression()
    {
        if (string.IsNullOrWhiteSpace(_keyword)) return review => true;

        return review => review.Content != null && review.Content.Value.ToUpper().Contains(_keyword.ToUpper());
    }
}