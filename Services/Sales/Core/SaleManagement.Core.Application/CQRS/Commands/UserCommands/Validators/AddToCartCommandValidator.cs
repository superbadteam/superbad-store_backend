using FluentValidation;
using SaleManagement.Core.Application.CQRS.Commands.UserCommands.Requests;

namespace SaleManagement.Core.Application.CQRS.Commands.UserCommands.Validators;

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