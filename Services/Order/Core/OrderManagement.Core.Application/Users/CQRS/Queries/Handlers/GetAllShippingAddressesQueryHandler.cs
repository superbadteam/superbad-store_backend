using BuildingBlock.Core.Application;
using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using OrderManagement.Core.Application.Users.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Users.DTOs;
using OrderManagement.Core.Domain.UserAggregate.Entities;
using OrderManagement.Core.Domain.UserAggregate.Specifications;

namespace OrderManagement.Core.Application.Users.CQRS.Queries.Handlers;

public class
    GetAllShippingAddressesQueryHandler : IQueryHandler<GetAllShippingAddressesQuery, IEnumerable<ShippingAddressDto>>
{
    private readonly ICurrentUser _currentUser;
    private readonly IReadOnlyRepository<ShippingAddress> _shippingAddressReadOnlyRepository;

    public GetAllShippingAddressesQueryHandler(IReadOnlyRepository<ShippingAddress> shippingAddressReadOnlyRepository,
        ICurrentUser currentUser)
    {
        _shippingAddressReadOnlyRepository = shippingAddressReadOnlyRepository;
        _currentUser = currentUser;
    }

    public async Task<IEnumerable<ShippingAddressDto>> Handle(GetAllShippingAddressesQuery request,
        CancellationToken cancellationToken)
    {
        var shippingAddressUserIdSpecification = new ShippingAddressUserIdSpecification(_currentUser.Id);

        return await _shippingAddressReadOnlyRepository.GetAllAsync<ShippingAddressDto>(
            shippingAddressUserIdSpecification);
    }
}