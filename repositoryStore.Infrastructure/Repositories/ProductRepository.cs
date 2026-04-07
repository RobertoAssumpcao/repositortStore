using Microsoft.EntityFrameworkCore;
using repositoryStore.Domain.Entities;
using repositoryStore.Domain.Repositories;
using repositoryStore.Infrastructure.Data;

namespace repositoryStore.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}