using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Academic.Student.Specifications.Selection
{
    public class GetStudentByIdSpecification : Specification<Limits.Student, Limits.Student>
    {
        public GetStudentByIdSpecification(long id) : base(x => x.Id == id)
        {
            AssignInclude(x => x.PhysicalPerson);
        }
    }
}
