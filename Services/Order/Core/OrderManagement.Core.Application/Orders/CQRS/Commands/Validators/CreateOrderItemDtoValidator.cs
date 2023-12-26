using FluentValidation;
using OrderManagement.Core.Application.Orders.DTOs;

namespace OrderManagement.Core.Application.Orders.CQRS.Commands.Validators;

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0);
    }
}