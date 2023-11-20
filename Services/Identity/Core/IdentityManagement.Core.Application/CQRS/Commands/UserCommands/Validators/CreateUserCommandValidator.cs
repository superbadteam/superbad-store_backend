using FluentValidation;
using IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Requests;

namespace IdentityManagement.Core.Application.CQRS.Commands.UserCommands.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Dto.Email)
            .CheckEmailValidation();

        RuleFor(command => command.Dto.Password)
            .CheckPasswordValidation();

        RuleFor(command => command.Dto.PhoneNumber)
            .CheckPhoneNumberValidation();
    }
}