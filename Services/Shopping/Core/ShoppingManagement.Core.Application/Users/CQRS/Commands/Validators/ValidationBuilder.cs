using FluentValidation;

namespace ShoppingManagement.Core.Application.Users.CQRS.Commands.Validators;

public static class ValidationBuilder
{
    public static IRuleBuilderOptions<T, int> CheckIfQuantityIsLargerThan0<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .Must(quantity => quantity > 0)
            .WithMessage("Quantity must be larger than 0.")
            .When(file => file != null);
    }
}