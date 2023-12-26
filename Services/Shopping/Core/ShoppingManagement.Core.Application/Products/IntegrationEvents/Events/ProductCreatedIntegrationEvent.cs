using BuildingBlock.Core.Application.IntegrationEvents.Events;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities.Enums;

namespace ShoppingManagement.Core.Application.Products.IntegrationEvents.Events;

public record ProductCreatedIntegrationEvent(ProductCreatedPayload Product) : IntegrationEvent;

public class ProductCreatedPayload
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public IEnumerable<ProductTypePayload> Types { get; set; } = null!;

    public ProductCondition Condition { get; set; }

    public IEnumerable<ProductImagePayload> Images { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}

public class ProductTypePayload
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}

public class ProductImagePayload
{
    public Guid Id { get; set; }

    public string Url { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}