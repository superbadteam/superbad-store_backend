using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using IdentityManagement.Core.Application.Users.CQRS.Commands.Requests;
using IdentityManagement.Core.Application.Users.IntegrationEvents.Events;
using IdentityManagement.Core.Domain.UserAggregate.DomainServices.Abstractions;
using IdentityManagement.Core.Domain.UserAggregate.Entities;
using IdentityManagement.Core.Domain.UserAggregate.Exceptions;
using IdentityManagement.Core.Domain.UserAggregate.Repositories;

namespace IdentityManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class RestoreUserCommandHandler : ICommandHandler<RestoreUserCommand>
{
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IUserOperationRepository _userOperationRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;

    public RestoreUserCommandHandler(IUserReadOnlyRepository userReadOnlyRepository, IUnitOfWork unitOfWork,
        IUserDomainService userDomainService, IUserOperationRepository userOperationRepository, IEventBus eventBus)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userDomainService = userDomainService;
        _userOperationRepository = userOperationRepository;
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RestoreUserCommand request, CancellationToken cancellationToken)
    {
        var user = Optional<User>.Of(await _userReadOnlyRepository.GetByIdAsync(request.UserId, null, true))
            .ThrowIfNotExist(new UserNotFoundException(request.UserId)).Get();

        _userDomainService.Restore(user);

        _userOperationRepository.Restore(user);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new UserRestoredIntegrationEvent(user.Id));
    }
}