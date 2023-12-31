using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;

namespace BuildingBlock.Core.Domain.Specifications.Implementations;

public class EntityIdNotEqualSpecification<TEntity> : Specification<TEntity> where TEntity : Entity
{
    private readonly Guid _id;

    public EntityIdNotEqualSpecification(Guid id)
    {
        _id = id;
    }

    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        return entity => entity.Id != _id;
    }
}