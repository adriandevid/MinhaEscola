using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class SchoolByIdSpecification : Specification<Limits.School, Limits.School>
    {
        public SchoolByIdSpecification(long id)
            : base(element => element.Id == id)
        {
            AssignInclude(x => x.Address);
            AssignInclude(x => x.SchoolComponents);
            AssignInclude(x => x.DisciplineComponents);
        }
    }
}
