using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.DTOs.OrderDTOs;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;

public record CreateOrderCommand(CreateOrderDto Dto) : ICommand<OrderDetailDto>;