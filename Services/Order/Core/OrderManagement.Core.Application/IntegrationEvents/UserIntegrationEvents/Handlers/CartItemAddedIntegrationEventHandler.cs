using BuildingBlock.Core.Application.IntegrationEvents.Handlers;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Events;
using OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;

namespace OrderManagement.Core.Application.IntegrationEvents.UserIntegrationEvents.Handlers;

public class CartItemAddedIntegrationEventHandler : IIntegrationEventHandler<CartItemAddedIntegrationEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public CartItemAddedIntegrationEventHandler(IReadOnlyRepository<User> userReadOnlyRepository,
        IUserDomainService userDomainService, IOperationRepository<User> userOperationRepository,
        IUnitOfWork unitOfWork)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userDomainService = userDomainService;
        _userOperationRepository = userOperationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CartItemAddedIntegrationEvent @event)
    {
        var specification = new EntityIdSpecification<User>(@event.UserId);

        var user = Optional<User>.Of(await _userReadOnlyRepository.GetAnyAsync(specification, "Carts"))
            .ThrowIfNotExist(new UserNotFoundException(@event.UserId)).Get();

        await _userDomainService.AddToCartAsync(user, @event.ProductTypeId, @event.Quantity);

        _userOperationRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();
    }
}