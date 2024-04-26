using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Base.Specifications;
using MinhaEscola.Service.Infrastructure.Data.Context;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TResult>> ApplySpecification<TResult>(Specification<TEntity, TResult> specification) where TResult : Entity
            => await _dbSet.GetQuery(specification).ToListAsync();

        public async Task<TResult> ApplySpecificationFirstOrDefault<TResult>(Specification<TEntity, TResult> specification) where TResult : Entity
        {
            var queryResult = await _dbSet.GetQuery(specification).FirstOrDefaultAsync();

            if (queryResult == null)
                throw new InvalidOperationException("Item not found!");

            return queryResult;
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetElementById(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new InvalidOperationException($"{typeof(TEntity).Name} not found!");
            }

            return entity;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
