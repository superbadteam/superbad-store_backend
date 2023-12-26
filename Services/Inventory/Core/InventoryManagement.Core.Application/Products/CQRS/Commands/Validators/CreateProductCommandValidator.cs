using FluentValidation;
using InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Dto.Name)
            .CheckProductNameValidation();

        RuleFor(x => x.Dto.Description)
            .CheckProductDescriptionValidation();

        RuleFor(x => x.Dto.Types)
            .NotEmpty()
            .WithMessage("Must has at least one type");

        RuleFor(x => x.Dto.Images)
            .NotEmpty()
            .WithMessage("Must has at least one image");

        RuleForEach(x => x.Dto.Types)
            .SetValidator(new CreateProductTypeDtoValidator());

        RuleForEach(x => x.Dto.Images)
            .SetValidator(new CreateProductImageDtoValidator());
    }
}