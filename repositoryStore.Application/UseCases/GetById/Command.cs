using MediatR;
using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Application.UseCases.GetById;

public sealed record class Command(int Id) : IRequest<Result<Response>>;
