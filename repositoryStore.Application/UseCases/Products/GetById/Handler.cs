using MediatR;
using repositoryStore.Domain.Abstractions;
using repositoryStore.Domain.Repositories;
using repositoryStore.Domain.Specifications.Products;

namespace repositoryStore.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var spec = new GetProductByIdSpecification(request.Id);
        var product = await repository.GetByIdAsync(spec, cancellationToken);

        return product is null
            ? Result.Failure<Response>(new Error("404", "Product not found"))
            : Result.Success<Response>(new Response(product.Id, product.Title));
    }
}