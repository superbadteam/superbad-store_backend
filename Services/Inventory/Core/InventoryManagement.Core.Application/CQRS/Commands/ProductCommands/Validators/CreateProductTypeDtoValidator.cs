using FluentValidation;
using InventoryManagement.Core.Application.DTOs.ProductDTOs;

namespace InventoryManagement.Core.Application.CQRS.Commands.ProductCommands.Validators;

public class CreateProductTypeDtoValidator : AbstractValidator<CreateProductTypeDto>
{
    public CreateProductTypeDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .CheckProductNameValidation();

        RuleFor(dto => dto.Quantity)
            .CheckQuantityValidation();

        RuleFor(dto => dto.Price)
            .CheckPriceValidation();
    }
}