using FluentValidation;
using OrderManagement.Core.Application.DTOs.OrderDTOs;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Validators;

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0);
    }
}