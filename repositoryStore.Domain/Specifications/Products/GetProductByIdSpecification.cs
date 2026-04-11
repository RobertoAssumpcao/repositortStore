using System.Linq.Expressions;
using repositoryStore.Domain.Abstractions;
using repositoryStore.Domain.Entities;

namespace repositoryStore.Domain.Specifications.Products;

public class GetProductByIdSpecification(int id) : Specification<Product>
{
    public override Expression<Func<Product, bool>> ToExpression()
    => product => product.Id == id;
}