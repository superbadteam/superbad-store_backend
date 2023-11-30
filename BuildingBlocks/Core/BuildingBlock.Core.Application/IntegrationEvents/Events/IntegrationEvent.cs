using System.Text.Json.Serialization;

namespace BuildingBlock.Core.Application.IntegrationEvents.Events;

public record IntegrationEvent
{
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
        Id = id;
        CreationDate = createDate;
    }

    [JsonInclude] public Guid Id { get; private init; }

    [JsonInclude] public DateTime CreationDate { get; private init; }
}

public record EntityCreatedIntegrationEvent(DateTime CreatedAt, string CreatedBy) : IntegrationEvent;