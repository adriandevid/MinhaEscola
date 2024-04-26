using MinhaEscola.Service.Domain.Base.Interfaces;

namespace MinhaEscola.Service.Domain.Academic.Class.Interfaces
{
    public interface IClassRepository : IBaseRepository<Limits.Class>
    {
        Task<List<Limits.Class>> GetClassesOfSchoolByUserReference(string userReference);
    }
}
