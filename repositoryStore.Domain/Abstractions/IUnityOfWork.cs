namespace repositoryStore.Domain.Abstractions;

public interface IUnityOfWork
{
    Task CommitAsync();
}