using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Board.School.Interfaces
{
    public interface ISchoolRepository : IBaseRepository<Limits.School>
    {
        Task<Limits.School> GetSchoolById(long id);
        
        Task<List<SchoolComponent>> GetComponentsOfSchool(long schoolId);
        Task<List<SchoolComponent>> GetComponentsOfSchoolByUserReference(string userReference);

        Task<Limits.School?> GetSchoolByUserReference(string userReference);
        
        Task<List<DisciplineComponent>> GetDisciplinesOfSchool(long schoolId);
        Task<DisciplineComponent> GetDisciplineComponent(long schoolId, long id);
    }
}
