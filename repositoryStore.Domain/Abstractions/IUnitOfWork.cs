namespace repositoryStore.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
}