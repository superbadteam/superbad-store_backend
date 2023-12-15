using FluentValidation;
using OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Dto.OrderItems)
            .NotEmpty()
            .WithMessage("Must has at least one item");

        RuleForEach(x => x.Dto.OrderItems)
            .SetValidator(new CreateOrderItemDtoValidator());
    }
}