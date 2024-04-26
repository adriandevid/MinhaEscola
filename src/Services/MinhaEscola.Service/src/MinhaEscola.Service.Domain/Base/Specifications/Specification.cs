using Microsoft.EntityFrameworkCore.Query;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using System.Linq.Expressions;

namespace MinhaEscola.Service.Domain.Base.Specifications
{
    public abstract class Specification<TEntity, TResult>
        where TEntity : Entity, IAggregateRoot
        where TResult : Entity
    {
        protected Specification() { }

        protected Specification(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }

        //Especifica os criterios que nossa entidade tem que satisfazer;
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpression { get; } = new();
        public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ThenIncludeExpression { get; } = new();

        public Expression<Func<TEntity, TResult>> OrderByExpression { get; private set; }
        public Expression<Func<TEntity, TResult>> OrderByDescendingExpression { get; private set; }

        public Expression<Func<TEntity, IEnumerable<TResult>>> SelectManyExpression { get; private set; }

        public void AssignInclude(Expression<Func<TEntity, object>> expression)
        {
            IncludeExpression.Add(expression);
        }

        public void AssignThenInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> expression)
        {
            ThenIncludeExpression.Add(expression);
        }


        public void AddOrderBy(Expression<Func<TEntity, TResult>> expression)
        {
            OrderByExpression = expression;
        }

        public void AddOrderByDescen(Expression<Func<TEntity, TResult>> expression)
        {
            OrderByExpression = expression;
        }

        public void AssignSelectMany(Expression<Func<TEntity, IEnumerable<TResult>>> expression)
        {
            SelectManyExpression = expression;
        }
    }
}
