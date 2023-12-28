using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using ReviewManagement.Core.Application.Users.IntegrationEvents.Events;
using ReviewManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using ReviewManagement.Core.Domain.UserAggregate.Entities;

namespace ReviewManagement.Core.Application.Users.IntegrationEvents.Handlers;

public class UserCreatedIntegrationEventHandler : IIntegrationEventHandler<UserCreatedIntegrationEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;

    public UserCreatedIntegrationEventHandler(IOperationRepository<User> userOperationRepository,
        IUnitOfWork unitOfWork, IUserDomainService userDomainService)
    {
        _userOperationRepository = userOperationRepository;
        _unitOfWork = unitOfWork;
        _userDomainService = userDomainService;
    }

    public async Task HandleAsync(UserCreatedIntegrationEvent @event)
    {
        var user = await _userDomainService.CreateAsync(@event.UserId, @event.Name, @event.AvatarUrl, @event.CreatedAt,
            @event.CreatedBy);

        await _userOperationRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();
    }
}