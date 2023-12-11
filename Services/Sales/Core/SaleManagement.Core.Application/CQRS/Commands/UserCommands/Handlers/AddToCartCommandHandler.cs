using AutoMapper;
using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using SaleManagement.Core.Application.CQRS.Commands.UserCommands.Requests;
using SaleManagement.Core.Application.DTOs.UserDTOs;
using SaleManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using SaleManagement.Core.Domain.UserAggregate.Entities;
using SaleManagement.Core.Domain.UserAggregate.Exceptions;
using SaleManagement.Core.Domain.UserAggregate.Specifications;

namespace SaleManagement.Core.Application.CQRS.Commands.UserCommands.Handlers;

public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand, CartDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public AddToCartCommandHandler(IReadOnlyRepository<User> userReadOnlyRepository, ICurrentUser currentUser,
        IUserDomainService userDomainService, IOperationRepository<User> userOperationRepository,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _currentUser = currentUser;
        _userDomainService = userDomainService;
        _userOperationRepository = userOperationRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CartDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var userIdSpecification = new UserIdSpecification(_currentUser.Id);

        var user = Optional<User>
            .Of(await _userReadOnlyRepository.GetAnyAsync(userIdSpecification, "Carts.ProductType.Product.Images"))
            .ThrowIfNotExist(new UserNotFoundException(_currentUser.Id)).Get();

        await _userDomainService.AddToCartAsync(user, request.Dto.ProductTypeId, request.Dto.Quantity);

        _userOperationRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CartDto>(user);
    }
}