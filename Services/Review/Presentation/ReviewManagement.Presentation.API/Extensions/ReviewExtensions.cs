using BuildingBlock.Presentation.API.Extensions;

namespace ReviewManagement.Presentation.API.Extensions;

public static class ReviewExtensions
{
    public static IServiceCollection AddReviewExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcAuthentication(configuration);
        services.AddGrpcAuthorization();

        return services;
    }
}