using BuildingBlock.Core.Domain.DomainEvents;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Domain.OrderAggregate.DomainEvents.Events;
using OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;

namespace OrderManagement.Core.Domain.UserAggregate.DomainEvents.Handlers;

public class OrderItemCreatedDomainEventHandler : IDomainEventHandler<OrderItemCreatedDomainEvent>
{
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public OrderItemCreatedDomainEventHandler(IReadOnlyRepository<User> userReadOnlyRepository,
        IUserDomainService userDomainService, IOperationRepository<User> userOperationRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userDomainService = userDomainService;
        _userOperationRepository = userOperationRepository;
    }

    public async Task Handle(OrderItemCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        if (notification.CartItemIds is null) return;

        var specification = new EntityIdSpecification<User>(notification.UserId);

        var user = Optional<User>.Of(await _userReadOnlyRepository.GetAnyAsync(specification, "Carts", false, true))
            .ThrowIfNotExist(new UserNotFoundException(notification.UserId)).Get();

        foreach (var cartItemId in notification.CartItemIds) _userDomainService.RemoveFromCart(user, cartItemId);

        _userOperationRepository.Update(user);
    }
}