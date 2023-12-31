using BuildingBlock.Core.Domain.ValueObject;
using FluentValidation;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects.Validator;

namespace ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

public sealed class Rating : ValueObject
{
    public Rating(int value)
    {
        Value = value;
        ValidateValues();
    }

    public int Value { get; }

    protected override void ValidateValues()
    {
        var validator = new RatingValidator();
        validator.ValidateAndThrow(this);
    }

    public override IEnumerable<object?> GetValues()
    {
        yield return Value;
    }
}