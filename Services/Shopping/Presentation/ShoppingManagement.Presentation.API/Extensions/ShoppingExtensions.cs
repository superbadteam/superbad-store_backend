using BuildingBlock.Presentation.API.Extensions;

namespace ShoppingManagement.Presentation.API.Extensions;

public static class ShoppingExtensions
{
    public static IServiceCollection AddShoppingExtensions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcAuthentication(configuration);
        services.AddGrpcAuthorization();

        return services;
    }
}