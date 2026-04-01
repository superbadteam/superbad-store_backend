using BuildingBlock.Core.Application.CQRS;

namespace IdentityManagement.Core.Application.Users.CQRS.Commands.Requests;

public record RestoreUserCommand(Guid UserId) : ICommand;