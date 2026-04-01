using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Services;
using MediatR;
using OrderManagement.Core.Application.Locations.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Users.CQRS.Commands.Requests;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Repositories;
using OrderManagement.Core.Domain.UserAggregate.ValueObjects;

namespace OrderManagement.Core.Application.Users.CQRS.Commands.Handlers;

public class SeedShippingAddressesCommandHandler : ICommandHandler<SeedShippingAddressesCommand>
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyRepository<User> _userReadOnlyRepository;
    private readonly IShippingAddressReadOnlyRepository _shippingAddressReadOnlyRepository;

    public SeedShippingAddressesCommandHandler(IReadOnlyRepository<User> userReadOnlyRepository, IMediator mediator,
        IUnitOfWork unitOfWork, IShippingAddressReadOnlyRepository shippingAddressReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
    }

    public async Task Handle(SeedShippingAddressesCommand request, CancellationToken cancellationToken)
    {
        var locations = await _mediator.Send(new GetAllLocationsQuery(), cancellationToken);

        var random = new Random();
        var pageSize = 1000;
        var pageIndex = 1;
        List<User> users;

        do
        {
            (users, _) = await _userReadOnlyRepository.GetFilterAndPagingAsync(
                null,
                "CreatedAt",
                pageIndex,
                pageSize,
                "ShippingAddresses",
                false,
                true);

            foreach (var user in users)
            {
                var randomLocation = locations[random.Next(locations.Count)];
                var randomDistrict = randomLocation.Districts[random.Next(randomLocation.Districts.Count)];
                
                user.ShippingAddresses[0].DistrictId =  randomDistrict.Id;
            }

            await _unitOfWork.SaveChangesAsync();

            pageIndex++;
        } while (users.Count == pageSize);
    }
}