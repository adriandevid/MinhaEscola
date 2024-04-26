using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;

namespace MinhaEscola.Service.Domain.Base.Specifications
{
    public static class SpecificationEvaluator
    {

        public static IQueryable<TResult> GetQuery<TEntity, TResult>(this IQueryable<TEntity> inputQueryable, Specification<TEntity, TResult> specification)
            where TEntity : Entity, IAggregateRoot
            where TResult : Entity
        {
            IQueryable<TEntity> query = inputQueryable;

            query = specification.ThenIncludeExpression.Aggregate(query, (current, includeExpression) => includeExpression(current));
            query = specification.IncludeExpression.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderByExpression is not null)
            {
                query = query.OrderBy(specification.OrderByExpression);
            }
            else if (specification.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingExpression);
            }

            if (specification.SelectManyExpression is not null)
            {
                return query.SelectMany(specification.SelectManyExpression);
            }

            return query.Cast<TResult>();
        }
    }
}
