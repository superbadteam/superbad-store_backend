using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.Users.DTOs;

namespace SaleManagement.Core.Application.Users.CQRS.Commands.Requests;

public record AddToCartCommand(AddToCartDto Dto) : ICommand<CartDto>;