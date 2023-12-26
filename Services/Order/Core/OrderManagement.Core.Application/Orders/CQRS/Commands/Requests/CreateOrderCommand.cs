using BuildingBlock.Core.Application.CQRS;
using OrderManagement.Core.Application.Orders.DTOs;
using OrderManagement.Core.Application.Orders.DTOs.Enums;

namespace OrderManagement.Core.Application.Orders.CQRS.Commands.Requests;

public record CreateOrderCommand(AddItemMethod Method, CreateOrderDto Dto) : ICommand<OrderDetailDto>;