using BuildingBlock.Core.Application.CQRS;
using ShoppingManagement.Core.Application.Users.DTOs;

namespace ShoppingManagement.Core.Application.Users.CQRS.Commands.Requests;

public record AddToCartCommand(AddToCartDto Dto) : ICommand<CartDto>;