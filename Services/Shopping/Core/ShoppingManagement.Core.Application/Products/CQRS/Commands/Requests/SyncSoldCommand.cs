using BuildingBlock.Core.Application.CQRS;

namespace ShoppingManagement.Core.Application.Products.CQRS.Commands.Requests;

public sealed record SyncSoldCommand : ICommand;