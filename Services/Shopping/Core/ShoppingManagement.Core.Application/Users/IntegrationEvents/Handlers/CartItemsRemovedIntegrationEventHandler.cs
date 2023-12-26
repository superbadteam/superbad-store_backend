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

public class CartItemsRemovedIntegrationEventHandler : IIntegrationEventHandler<CartItemsRemovedIntegrationEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public CartItemsRemovedIntegrationEventHandler(IOperationRepository<User> userOperationRepository,
        IReadOnlyRepository<User> userReadOnlyRepository, IUserDomainService userDomainService, IUnitOfWork unitOfWork)
    {
        _userOperationRepository = userOperationRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _userDomainService = userDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CartItemsRemovedIntegrationEvent @event)
    {
        var specification = new EntityIdSpecification<User>(@event.UserId);

        var user = Optional<User>.Of(await _userReadOnlyRepository.GetAnyAsync(specification, "Carts", false, true))
            .ThrowIfNotExist(new UserNotFoundException(@event.UserId)).Get();

        foreach (var cartItemId in @event.CartItemIds) _userDomainService.RemoveFromCart(user, cartItemId);

        _userOperationRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();
    }
}