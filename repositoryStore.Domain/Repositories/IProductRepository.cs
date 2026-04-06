using repositoryStore.Domain.Entities;

namespace repositoryStore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}