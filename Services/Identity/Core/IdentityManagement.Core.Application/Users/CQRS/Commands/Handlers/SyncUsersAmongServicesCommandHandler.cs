using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using IdentityManagement.Core.Application.Users.CQRS.Commands.Requests;
using IdentityManagement.Core.Application.Users.IntegrationEvents.Events;
using IdentityManagement.Core.Domain.UserAggregate.Repositories;

namespace IdentityManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class SyncUsersAmongServicesCommandHandler : ICommandHandler<SyncUsersAmongServicesCommand>
{
    private readonly IEventBus _eventBus;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;


    public SyncUsersAmongServicesCommandHandler(IEventBus eventBus, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _eventBus = eventBus;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task Handle(SyncUsersAmongServicesCommand request, CancellationToken cancellationToken)
    {
        var users = await _userReadOnlyRepository.GetAllAsync();

        foreach (var user in users)
            _eventBus.Publish(new UserCreatedIntegrationEvent(user.Id, user.Name, user.AvatarUrl, user.CoverUrl,
                DateTime.UtcNow, "Sync"));
    }
}