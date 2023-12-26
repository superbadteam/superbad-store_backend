using FluentValidation;
using ShoppingManagement.Core.Application.Users.CQRS.Commands.Requests;

namespace ShoppingManagement.Core.Application.Users.CQRS.Commands.Validators;

public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
{
    public AddToCartCommandValidator()
    {
        RuleFor(x => x.Dto.ProductTypeId)
            .NotEmpty();

        RuleFor(x => x.Dto.Quantity)
            .NotEmpty()
            .CheckIfQuantityIsLargerThan0();
    }
}