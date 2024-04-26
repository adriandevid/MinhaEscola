using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class GetDisciplinesComponentsSpecification : Specification<Limits.School, Limits.DisciplineComponent>
    {
        public GetDisciplinesComponentsSpecification(long id)
            : base(element => element.Id == id)
        {
            AssignThenInclude(x => x.Include(x => x.DisciplineComponents).ThenInclude(x => x.Component));
            AssignThenInclude(x => x.Include(x => x.DisciplineComponents).ThenInclude(x => x.Discipline));
            AssignSelectMany(x => x.DisciplineComponents);
        }
    }
}
