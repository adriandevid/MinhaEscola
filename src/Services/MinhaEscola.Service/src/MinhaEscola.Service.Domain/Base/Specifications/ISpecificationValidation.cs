using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Base.Specifications
{
    public interface ISpecificationValidation<TEntity> where TEntity : Entity
    {
        bool IsValid(TEntity entity);
    }
}
