using System.Text.Json;
using System.Text.Json.Serialization;
using BuildingBlock.Core.Domain.Repositories;
using BuildingBlock.Core.Domain.Shared.Utils;
using Microsoft.Extensions.Logging;
using ShoppingManagement.Core.Application;
using ShoppingManagement.Core.Domain.UserAggregate.Entities;
using ShoppingManagement.Core.Domain.UserAggregate.Exceptions;
using ShoppingManagement.Core.Domain.UserAggregate.Specifications;

namespace ShoppingManagement.Infrastructure.EntityFrameworkCore;

public class RecommendationService : IRecommendationService
{
    private readonly ILogger<RecommendationService> _logger;
    private readonly IReadOnlyRepository<UserIdMap> _userIdMapRepository;

    public RecommendationService(IReadOnlyRepository<UserIdMap> userIdMapRepository,
        ILogger<RecommendationService> logger)
    {
        _userIdMapRepository = userIdMapRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Guid>> GetRecommendedProductIds(Guid userId)
    {
        var user = await EntityHelper.GetOrThrowAsync(new UserIdMapGuidSpecification(userId),
            new UserNotFoundException(userId),
            _userIdMapRepository);

        using var httpClient = new HttpClient();
        var url = $"https://4e74-35-187-148-21.ngrok-free.app/recommend?user_id={user.StringUserId}";

        _logger.LogInformation($"Fetching recommendations for user: {userId} from {url}");

        var response = await httpClient.GetStringAsync(url);
        var jsonResponse = JsonSerializer.Deserialize<RecommendationResponse>(response);

        _logger.LogInformation($"Received recommendations for user: {userId} - {jsonResponse}");

        if (jsonResponse?.Recommendations == null) throw new Exception("Invalid response from recommendation service.");

        return jsonResponse.Recommendations.Select(x => x.ToGuid());
    }
    
    public async Task<IEnumerable<Guid>> GetProductRecommendations(Guid productId)
    {
        using var httpClient = new HttpClient();
        var url = $"https://4e74-35-187-148-21.ngrok-free.app/products/{productId}/recommended";

        _logger.LogInformation($"Fetching recommendations for products: {productId}");

        var response = await httpClient.GetStringAsync(url);
        var jsonResponse = JsonSerializer.Deserialize<RecommendationResponse>(response);

        _logger.LogInformation($"Received recommendations: {jsonResponse}");

        if (jsonResponse?.Recommendations == null) throw new Exception("Invalid response from recommendation service.");

        return jsonResponse.Recommendations.Select(Guid.Parse);
    }

    public class RecommendationResponse
    {
        [JsonPropertyName("recommendations")] public List<string> Recommendations { get; set; }

        [JsonPropertyName("user_id")] public string UserId { get; set; }
    }
}