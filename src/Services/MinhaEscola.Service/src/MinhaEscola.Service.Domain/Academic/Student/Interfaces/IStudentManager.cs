using MinhaEscola.Service.Domain.Academic.Student.Limits;

namespace MinhaEscola.Service.Domain.Academic.Student.Interfaces
{
    public interface IStudentManager
    {
        Task CreateAEnrollmentFoClass(Enrollment enrollment, long @class);
    }
}
