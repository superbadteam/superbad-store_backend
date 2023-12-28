using FluentValidation;

namespace ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects.Validator;

public class ContentValidator : AbstractValidator<Content>
{
    public ContentValidator()
    {
        RuleFor(content => content.Value)
            .MinimumLength(20)
            .WithMessage("Content must be at least 20 characters long.");
    }
}