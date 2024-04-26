using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class GetSchoolByUserSpecification : Specification<Limits.School, Limits.School>
    {
        public GetSchoolByUserSpecification(string user)
            : base(element => element.UsersSchool.Any(userSchool => userSchool.UserId == user))
        {
            AssignInclude(x => x.UsersSchool);
            AssignInclude(x => x.DisciplineComponents);
        }
    }
}
