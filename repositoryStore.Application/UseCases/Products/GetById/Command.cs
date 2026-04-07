using MediatR;
using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Application.UseCases.Products.GetById;

public sealed record class Command(int Id) : IRequest<Result<Response>>;
