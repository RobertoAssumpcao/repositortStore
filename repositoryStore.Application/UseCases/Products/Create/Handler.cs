using MediatR;
using repositoryStore.Domain.Abstractions;
using repositoryStore.Domain.Entities;
using repositoryStore.Domain.Repositories;

namespace repositoryStore.Application.UseCases.Products.Create;

public class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = 1,
            Title = request.Title,
            Slug = request.Slug,
            CreatedAtUtc = DateTime.UtcNow
        };
        
        await repository.CreateAsync(product, cancellationToken);
        await unitOfWork.CommitAsync();
        
        return Result.Success(new Response("Produto criado com sucesso"));
    }
}