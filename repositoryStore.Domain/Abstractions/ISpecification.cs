using System.Linq.Expressions;

namespace repositoryStore.Domain.Abstractions;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();
    bool IsSatisfiedBy(T entity);
}