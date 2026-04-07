using MediatR;
using repositoryStore.Domain.Abstractions;
using repositoryStore.Domain.Repositories;

namespace repositoryStore.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        return product is null
            ? Result.Failure<Response>(new Error("404", "Product not found"))
            : Result.Success<Response>(new Response(product.Id, product.Title));
    }
}