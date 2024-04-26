using MinhaEscola.Service.Domain.Base.Interfaces;
using StudentEntitie = MinhaEscola.Service.Domain.Academic.Student.Limits.Student;

namespace MinhaEscola.Service.Domain.Academic.Student.Interfaces
{
    public interface IStudentRepository : IBaseRepository<StudentEntitie>
    {
        Task<StudentEntitie> GetById(long id);
    }
}
