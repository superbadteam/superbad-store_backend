using BuildingBlock.Core.Application.CQRS;
using BuildingBlock.Core.Domain.Repositories;
using OrderManagement.Core.Application.Locations.CQRS.Queries.Requests;
using OrderManagement.Core.Application.Locations.DTOs;
using OrderManagement.Core.Domain.LocationAggregate.Entities;
using OrderManagement.Core.Domain.LocationAggregate.Specifications;

namespace OrderManagement.Core.Application.Locations.CQRS.Queries.Handlers;

public class GetAllLocationsQueryHandler : IQueryHandler<GetAllLocationsQuery, List<CityDto>>
{
    private readonly IReadOnlyRepository<Location> _locationReadOnlyRepository;

    public GetAllLocationsQueryHandler(IReadOnlyRepository<Location> locationReadOnlyRepository)
    {
        _locationReadOnlyRepository = locationReadOnlyRepository;
    }

    public Task<List<CityDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        var locationIsCitySpecification = new LocationIsCitySpecification();

        return _locationReadOnlyRepository.GetAllAsync<CityDto>(locationIsCitySpecification);
    }
}