using BuildingBlock.Presentation.API.Extensions;

namespace InventoryManagement.Presentation.API.Extensions;

public static class ProductExtensions
{
    public static IServiceCollection AddInventoryExtensions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcAuthentication(configuration);
        services.AddGrpcAuthorization();

        return services;
    }
}