using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using ReviewManagement.Core.Application.Users.IntegrationEvents.Events;
using ReviewManagement.Core.Domain.UserAggregate.Entities;
using ReviewManagement.Core.Domain.UserAggregate.Exceptions;

namespace ReviewManagement.Core.Application.Users.IntegrationEvents.Handlers;

public class UserDeletedIntegrationEventHandler : IIntegrationEventHandler<UserDeletedIntegrationEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDeletedIntegrationEventHandler(IReadOnlyRepository<User> userReadOnlyRepository, IUnitOfWork unitOfWork,
        IOperationRepository<User> userOperationRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _userOperationRepository = userOperationRepository;
    }

    public async Task HandleAsync(UserDeletedIntegrationEvent @event)
    {
        var user = await EntityHelper.GetOrThrowAsync(@event.UserId, new UserNotFoundException(@event.UserId),
            _userReadOnlyRepository);

        _userOperationRepository.Delete(user);

        await _unitOfWork.SaveChangesAsync();
    }
}