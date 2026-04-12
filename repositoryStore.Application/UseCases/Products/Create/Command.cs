using MediatR;
using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Application.UseCases.Products.Create;

public sealed record Command(string Title, string Slug) : IRequest<Result<Response>>;