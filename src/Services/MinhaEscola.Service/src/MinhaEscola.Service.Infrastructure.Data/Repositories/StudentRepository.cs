using MinhaEscola.Service.Domain.Academic.Student.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Limits;
using MinhaEscola.Service.Domain.Academic.Student.Specifications.Selection;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Student> GetById(long id)
         => await ApplySpecificationFirstOrDefault(new GetStudentByIdSpecification(id));
    }
}
