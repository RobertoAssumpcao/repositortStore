using Microsoft.Extensions.DependencyInjection;
using repositoryStore.Domain.Repositories;
using repositoryStore.Infrastructure.Repositories;

namespace repositoryStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        
        return services;
    }
}