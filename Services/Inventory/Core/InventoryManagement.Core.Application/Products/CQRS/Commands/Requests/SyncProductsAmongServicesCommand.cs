using BuildingBlock.Core.Application.CQRS;

namespace InventoryManagement.Core.Application.Products.CQRS.Commands.Requests;

public record SyncProductsAmongServicesCommand : ICommand;