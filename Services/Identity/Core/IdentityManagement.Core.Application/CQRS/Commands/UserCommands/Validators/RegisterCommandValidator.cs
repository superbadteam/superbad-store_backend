using FluentValidation;
using IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Requests;

namespace IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.Dto.Email)
            .CheckEmailValidation();

        RuleFor(command => command.Dto.Password)
            .CheckPasswordValidation();
    }
}