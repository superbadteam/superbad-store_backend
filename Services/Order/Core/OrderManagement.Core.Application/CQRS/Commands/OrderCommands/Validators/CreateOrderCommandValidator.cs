using FluentValidation;
using OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;
using OrderManagement.Core.Application.DTOs.OrderDTOs.Enums;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Dto.OrderItems)
            .NotEmpty()
            .WithMessage("Must has at least one item")
            .When(x => x.Method == AddItemMethod.Direct)
            .Null()
            .WithMessage("Must be null")
            .When(x => x.Method == AddItemMethod.TakeFromCart);

        RuleFor(x => x.Dto.CartItemIds)
            .NotEmpty()
            .WithMessage("Must has at least one item")
            .When(x => x.Method == AddItemMethod.TakeFromCart)
            .Null()
            .WithMessage("Must be null")
            .When(x => x.Method == AddItemMethod.Direct);

        RuleForEach(x => x.Dto.OrderItems)
            .SetValidator(new CreateOrderItemDtoValidator())
            .When(x => x.Method == AddItemMethod.Direct);
    }
}