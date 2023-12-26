using FluentValidation;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Validators;

public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
{
    public CreateProductImageDtoValidator()
    {
        RuleFor(dto => dto.Url)
            .CheckImageUrlValidation();
    }
}