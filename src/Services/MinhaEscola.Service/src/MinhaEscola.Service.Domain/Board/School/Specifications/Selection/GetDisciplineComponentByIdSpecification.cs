using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class GetDisciplineComponentByIdSpecification : Specification<Limits.School, Limits.DisciplineComponent>
    {
        public GetDisciplineComponentByIdSpecification(long schoolId, long id)
            : base(element => element.Id == schoolId)
        {
            AssignInclude(entity => entity.DisciplineComponents);
            AssignThenInclude(query => query.Include(entity => entity.DisciplineComponents).ThenInclude(x => x.Component));
            AssignThenInclude(query => query.Include(entity => entity.DisciplineComponents).ThenInclude(x => x.Discipline));

            AssignThenInclude(query => query.Include(entity => entity.SchoolComponents).ThenInclude(entity => entity.Component));
            AssignSelectMany(entity => entity.DisciplineComponents.Where(x => x.Id == id));
        }
    }
}
