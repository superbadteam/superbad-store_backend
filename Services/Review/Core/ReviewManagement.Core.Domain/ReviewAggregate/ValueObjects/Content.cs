using BuildingBlock.Core.Domain.ValueObject;
using FluentValidation;
using ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects.Validator;

namespace ReviewManagement.Core.Domain.ReviewAggregate.ValueObjects;

public sealed class Content : ValueObject
{
    public Content(string value)
    {
        Value = value;
        ValidateValues();
    }

    public string Value { get; }

    protected override void ValidateValues()
    {
        var validator = new ContentValidator();
        validator.ValidateAndThrow(this);
    }

    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}