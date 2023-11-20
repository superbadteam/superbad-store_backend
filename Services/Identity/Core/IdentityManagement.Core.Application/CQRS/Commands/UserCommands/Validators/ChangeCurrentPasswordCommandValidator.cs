using FluentValidation;
using IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Requests;

namespace IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Validators;

public class ChangeCurrentPasswordCommandValidator : AbstractValidator<ChangeCurrentPasswordCommand>
{
    public ChangeCurrentPasswordCommandValidator()
    {
        RuleFor(x => x.Dto.NewPassword)
            .CheckPasswordValidation();
    }
}