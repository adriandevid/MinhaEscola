using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class GetComponentsOfSchoolByUserSpecification : Specification<Limits.School, Limits.SchoolComponent>
    {
        public GetComponentsOfSchoolByUserSpecification(string user)
            : base(element => element.UsersSchool.Any(userSchool => userSchool.UserId == user))
        {
            AssignInclude(entity => entity.UsersSchool);
            AssignThenInclude(query => query.Include(entity => entity.SchoolComponents).ThenInclude(entity => entity.Component));
            AssignSelectMany(entity => entity.SchoolComponents);
        }
    }
}
