using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Domain.Entities;

public class Product : Entity
{
    public string Title { get; set; } = string.Empty;
}