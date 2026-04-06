using MediatR;

namespace repositoryStore.Application.UseCases.GetById;

public sealed record class Command(int Id) : IRequest<Response>;
