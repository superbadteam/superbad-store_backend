using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Locations.DTOs;

namespace OrderManagement.Core.Application.Locations.CQRS.Queries.Requests;

public record GetAllLocationsQuery : IQuery<List<CityDto>>;