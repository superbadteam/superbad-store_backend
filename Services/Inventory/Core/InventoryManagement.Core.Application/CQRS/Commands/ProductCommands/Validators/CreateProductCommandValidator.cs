using FluentValidation;
using InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Requests;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Dto.Name)
            .CheckProductNameValidation();

        RuleFor(command => command.Dto.Description)
            .CheckProductDescriptionValidation();

        RuleForEach(command => command.Dto.Types)
            .SetValidator(new CreateProductTypeDtoValidator());
    }
}