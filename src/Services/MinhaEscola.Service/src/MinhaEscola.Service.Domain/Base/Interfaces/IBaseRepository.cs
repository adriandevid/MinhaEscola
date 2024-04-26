using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Base.Interfaces
{
    public interface IBaseRepository<Type> where Type : Entity, IAggregateRoot
    {
        void Create(Type entity);
        void Update(Type entity);
        void Delete(Type entity);
        Task<Type?> GetElementById(long id);
        Task<List<Type>> GetAll();
        Task<List<TResult>> ApplySpecification<TResult>(Specification<Type, TResult> specification) where TResult : Entity;
        Task<TResult> ApplySpecificationFirstOrDefault<TResult>(Specification<Type, TResult> specification) where TResult : Entity;
    }
}
