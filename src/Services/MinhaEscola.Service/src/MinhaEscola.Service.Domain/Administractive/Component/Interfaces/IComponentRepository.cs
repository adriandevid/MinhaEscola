using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;

namespace MinhaEscola.Service.Domain.Administractive.Component.Interfaces
{
    public interface IComponentRepository : IBaseRepository<Component.Limits.Component>
    {
        Task<List<Denomination>> GetAllDenominations();
        Task<Denomination> GetDenominationById(long denominationId);
    }
}
