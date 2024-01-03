using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using ShoppingManagement.Core.Application.Users.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;
using ShoppingManagement.Core.Domain.UserAggregate.Exceptions;

namespace ShoppingManagement.Core.Application.Users.IntegrationEvents.Handlers;

public class UserDeletedIntegrationEventHandler : IIntegrationEventHandler<UserDeletedIntegrationEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public UserDeletedIntegrationEventHandler(IReadOnlyRepository<User> userReadOnlyRepository, IUnitOfWork unitOfWork,
        IOperationRepository<User> userOperationRepository, IUserDomainService userDomainService)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _unitOfWork = unitOfWork;
        _userOperationRepository = userOperationRepository;
        _userDomainService = userDomainService;
    }

    public async Task HandleAsync(UserDeletedIntegrationEvent @event)
    {
        var user = Optional<User>
            .Of(await _userReadOnlyRepository.GetAnyAsync(new EntityIdSpecification<User>(@event.UserId),
                "Products.Types"))
            .ThrowIfNotExist(new UserNotFoundException(@event.UserId)).Get();

        _userDomainService.Delete(user, @event.DeletedAt, @event.DeletedBy);

        _userOperationRepository.Delete(user);

        await _unitOfWork.SaveChangesAsync();
    }
}