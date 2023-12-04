using BuildingBlock.Core.Application.IntegrationEvents.Events;

namespace SaleManagement.Core.Application.IntegrationEvents.CategoryIntegrationEvents.Events;

public record CategoryCreatedIntegrationEvent(CategoryCreatedPayload Category) : IntegrationEvent;

public class CategoryCreatedPayload
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? ParentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;
}