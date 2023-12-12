using BuildingBlock.Presentation.API.Extensions;

namespace OrderManagement.Presentation.API.Extensions;

public static class OrderExtensions
{
    public static IServiceCollection AddOrderExtensions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcAuthentication(configuration);
        services.AddGrpcAuthorization();

        return services;
    }
}