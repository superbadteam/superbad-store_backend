using BuildingBlock.Core.Application.CQRS;
using SaleManagement.Core.Application.DTOs.UserDTOs;

namespace SaleManagement.Core.Application.CQRS.Commands.UserCommands.Requests;

public record AddToCartCommand(AddToCartDto Dto) : ICommand<CartDto>;