namespace ShoppingManagement.Core.Application;

public interface IRecommendationService
{
    Task<IEnumerable<Guid>> GetRecommendedProductIds(Guid userId);

    Task<IEnumerable<Guid>> GetProductRecommendations(Guid productId);
}