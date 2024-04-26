using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Board.School.Interfaces;
using MinhaEscola.Service.Domain.Board.School.Limits;
using MinhaEscola.Service.Domain.Board.School.Specifications.Selection;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        public SchoolRepository(ApplicationContext context) : base(context) {}

        public async Task<School> GetSchoolById(long id)
          => await ApplySpecificationFirstOrDefault(new SchoolByIdSpecification(id));

        public async Task<List<SchoolComponent>> GetComponentsOfSchool(long schoolId)
          => await ApplySpecification(new GetComponentsOfSchoolSpecification(schoolId));

        public async Task<List<DisciplineComponent>> GetDisciplinesOfSchool(long schoolId)
          => await ApplySpecification(new GetDisciplinesComponentsSpecification(schoolId));

        public async Task<School?> GetSchoolByUserReference(string userReference)
          => await ApplySpecificationFirstOrDefault(new GetSchoolByUserSpecification(userReference));

        public async Task<List<SchoolComponent>> GetComponentsOfSchoolByUserReference(string userReference)
          => await ApplySpecification(new GetComponentsOfSchoolByUserSpecification(userReference));

        public async Task<DisciplineComponent> GetDisciplineComponent(long schoolId, long id)
            => await ApplySpecificationFirstOrDefault(new GetDisciplineComponentByIdSpecification(schoolId, id));
    }
}
