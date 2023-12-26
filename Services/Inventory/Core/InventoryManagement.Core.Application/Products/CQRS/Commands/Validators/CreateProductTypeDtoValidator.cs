using FluentValidation;
using InventoryManagement.Core.Application.Products.ProductDTOs;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Validators;

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