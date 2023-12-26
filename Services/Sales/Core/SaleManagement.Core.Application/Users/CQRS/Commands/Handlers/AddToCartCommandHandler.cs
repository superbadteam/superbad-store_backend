using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Application.EventBus.Abstractions;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using SaleManagement.Core.Application.Users.CQRS.Commands.Requests;
using SaleManagement.Core.Application.Users.DTOs;
using SaleManagement.Core.Application.Users.IntegrationEvents.Events;
using SaleManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Specifications;

namespace SaleManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand, CartDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public AddToCartCommandHandler(IReadOnlyRepository<User> userReadOnlyRepository, ICurrentUser currentUser,
        IUserDomainService userDomainService, IOperationRepository<User> userOperationRepository,
        IUnitOfWork unitOfWork, IEventBus eventBus)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _currentUser = currentUser;
        _userDomainService = userDomainService;
        _userOperationRepository = userOperationRepository;
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
    }

    public async Task<CartDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var userIdSpecification = new UserIdSpecification(_currentUser.Id);

        var user = Optional<User>
            .Of(await _userReadOnlyRepository.GetAnyAsync(userIdSpecification, "Carts"))
            .ThrowIfNotExist(new UserNotFoundException(_currentUser.Id)).Get();

        var cartItem = await _userDomainService.AddToCartAsync(user, request.Dto.ProductTypeId, request.Dto.Quantity);

        _userOperationRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();

        _eventBus.Publish(new CartItemAddedIntegrationEvent(_currentUser.Id, cartItem.Id, request.Dto.ProductTypeId,
            request.Dto.Quantity));

        return Optional<CartDto>
            .Of(await _userReadOnlyRepository.GetAnyAsync<CartDto>(userIdSpecification))
            .ThrowIfNotExist(new UserNotFoundException(_currentUser.Id)).Get();
    }
}