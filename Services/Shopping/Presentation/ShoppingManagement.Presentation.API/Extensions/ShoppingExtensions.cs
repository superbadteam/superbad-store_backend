using BuildingBlock.Presentation.API.Extensions;
using ShoppingManagement.Core.Application;
using ShoppingManagement.Infrastructure.EntityFrameworkCore;

namespace ShoppingManagement.Presentation.API.Extensions;

public static class ShoppingExtensions
{
    public static IServiceCollection AddShoppingExtensions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpcAuthentication(configuration);
        services.AddGrpcAuthorization();
        services.AddScoped<IRecommendationService, RecommendationService>();

        return services;
    }
}