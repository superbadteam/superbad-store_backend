using FluentValidation;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Validators;

public static class ValidationBuilder
{
    public static IRuleBuilderOptions<T, string> CheckProductNameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty();
    }

    public static IRuleBuilderOptions<T, double> CheckPriceValidation<T>(this IRuleBuilder<T, double> ruleBuilder)
    {
        return ruleBuilder
            .GreaterThanOrEqualTo(0);
    }

    public static IRuleBuilderOptions<T, int> CheckQuantityValidation<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .GreaterThanOrEqualTo(0);
    }

    public static IRuleBuilderOptions<T, string> CheckImageUrlValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty();
    }
}