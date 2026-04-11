using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Domain.Entities;

public class Product : Entity,  IAggregateRoot
{
    public required string Title { get; set; }
    public required string Slug { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}