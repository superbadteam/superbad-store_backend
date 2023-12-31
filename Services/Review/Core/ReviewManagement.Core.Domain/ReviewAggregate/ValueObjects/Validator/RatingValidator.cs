using FluentValidation;

namespace ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects.Validator;

public class RatingValidator : AbstractValidator<Rating>
{
    public RatingValidator()
    {
        RuleFor(rating => rating.Value)
            .InclusiveBetween(1, 5)
            .WithMessage("Rating must be between 1 and 5.");
    }
}