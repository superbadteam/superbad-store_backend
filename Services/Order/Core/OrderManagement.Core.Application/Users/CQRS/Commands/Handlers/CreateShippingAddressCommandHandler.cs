using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using BuildingBlock.Core.Domain.Shared.Utils;
using BuildingBlock.Core.Domain.Specifications.Implementations;
using OrderManagement.Core.Application.Users.CQRS.Commands.Requests;
using OrderManagement.Core.Application.Users.DTOs;
using OrderManagement.Core.Domain.UserAggregate.DomainServices.Adstractions;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Exceptions;
using OrderManagement.Core.Domain.UserAggregate.ValueObjects;

namespace OrderManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class CreateShippingAddressCommandHandler : ICommandHandler<CreateShippingAddressCommand, ShippingAddressDto>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<ShippingAddress> _shippingAddressReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserDomainService _userDomainService;
    private readonly IOperationRepository<User> _userOperationRepository;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;

    public CreateShippingAddressCommandHandler(IUserDomainService userDomainService, ICurrentUser currentUser,
        IReadOnlyRepository<User> userReadOnlyRepository, IOperationRepository<User> userOperationRepository,
        IUnitOfWork unitOfWork, IReadOnlyRepository<ShippingAddress> shippingAddressReadOnlyRepository)
    {
        _userDomainService = userDomainService;
        _currentUser = currentUser;
        _userReadOnlyRepository = userReadOnlyRepository;
        _userOperationRepository = userOperationRepository;
        _unitOfWork = unitOfWork;
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
    }

    public async Task<ShippingAddressDto> Handle(CreateShippingAddressCommand request,
        CancellationToken cancellationToken)
    {
        var user = await EntityHelper.GetOrThrowAsync(_currentUser.Id, new UserNotFoundException(_currentUser.Id),
            _userReadOnlyRepository);

        if (request.Dto.IsMainAddress)
            await _userDomainService.RemoveMainAddressStatusFromCurrentShippingAddressAsync(user);

        var phoneNumber = new PhoneNumber(request.Dto.PhoneNumber.CountryCode, request.Dto.PhoneNumber.NationalNumber);

        var shippingAddress = await _userDomainService.CreateShippingAddressAsync(user, request.Dto.Name, phoneNumber,
            request.Dto.DistrictId, request.Dto.Address, request.Dto.IsMainAddress);

        _userOperationRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return Optional<ShippingAddressDto>.Of(await _shippingAddressReadOnlyRepository.GetAnyAsync<ShippingAddressDto>(
                new EntityIdSpecification<ShippingAddress>(shippingAddress.Id)))
            .ThrowIfNotExist(new ShippingAddressNotFoundException(shippingAddress.Id, user.Id)).Get();
    }
}