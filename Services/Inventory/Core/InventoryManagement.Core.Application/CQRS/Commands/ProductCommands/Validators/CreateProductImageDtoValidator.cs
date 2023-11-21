using FluentValidation;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Validators;

public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
{
    public CreateProductImageDtoValidator()
    {
        RuleFor(dto => dto.Url)
            .CheckImageUrlValidation();
    }
}