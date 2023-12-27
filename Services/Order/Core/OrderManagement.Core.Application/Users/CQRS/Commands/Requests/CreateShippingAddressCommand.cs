using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Users.DTOs;

namespace OrderManagement.Core.Application.Users.CQRS.Commands.Requests;

public record CreateShippingAddressCommand(CreateShippingAddressDto Dto) : ICommand<ShippingAddressDto>;