using repositoryStore.Domain.Abstractions;

namespace repositoryStore.Domain.Repositories;

public interface IRepository<T> where T : Entity;