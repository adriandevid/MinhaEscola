using MinhaEscola.Service.Domain.Base.Interfaces;

namespace MinhaEscola.Service.Domain.Administractive.Stage.Interfaces
{
    public interface IStageRepository : IBaseRepository<Limits.Stage>
    {
        Task<Limits.Stage> GetByIdWithAllIncludes(long id);
    }
}
