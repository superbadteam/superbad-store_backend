using FluentValidation;
using SaleManagement.Core.Application.Users.CQRS.Commands.Requests;

namespace SaleManagement.Core.Application.Users.CQRS.Commands.Validators;

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