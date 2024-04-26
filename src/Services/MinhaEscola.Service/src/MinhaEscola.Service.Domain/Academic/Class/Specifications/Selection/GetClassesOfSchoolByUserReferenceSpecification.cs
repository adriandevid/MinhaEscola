using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Base.Specifications;

namespace MinhaEscola.Service.Domain.Academic.Class.Specifications.Selection
{
    public class GetClassesOfSchoolByUserReferenceSpecification : Specification<Limits.Class, Limits.Class>
    {
        public GetClassesOfSchoolByUserReferenceSpecification(string user) : base(x => x.School.UsersSchool.Any(x => x.UserId == user))
        {
            AssignInclude(x => x.School);
            AssignInclude(x => x.Component);
            AssignThenInclude(x => x.Include(@class => @class.School).ThenInclude(school => school.UsersSchool));
        }
    }
}
