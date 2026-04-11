using Microsoft.EntityFrameworkCore;
using repositoryStore.Domain.Abstractions;
using repositoryStore.Domain.Entities;
using repositoryStore.Domain.Repositories;
using repositoryStore.Infrastructure.Data;

namespace repositoryStore.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Specification<Product> specification,
        CancellationToken cancellationToken = default)
        => await context.Products.Where(specification.ToExpression()).FirstOrDefaultAsync(cancellationToken);
}