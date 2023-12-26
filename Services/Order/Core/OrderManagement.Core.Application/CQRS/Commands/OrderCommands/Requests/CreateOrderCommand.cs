using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.DTOs.OrderDTOs;
using OrderManagement.Core.Application.DTOs.OrderDTOs.Enums;

namespace OrderManagement.Core.Application.CQRS.Commands.OrderCommands.Requests;

public record CreateOrderCommand(AddItemMethod Method, CreateOrderDto Dto) : ICommand<OrderDetailDto>;