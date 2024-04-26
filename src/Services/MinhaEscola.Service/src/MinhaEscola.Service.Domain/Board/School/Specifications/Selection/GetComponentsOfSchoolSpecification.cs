using MinhaEscola.Service.Domain.Base.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Domain.Board.School.Specifications.Selection
{
    public class GetComponentsOfSchoolSpecification : Specification<Limits.School, Limits.SchoolComponent>
    {
        public GetComponentsOfSchoolSpecification(long id)
            : base(element => element.Id == id)
        {
            AssignInclude(x => x.SchoolComponents);
            AssignSelectMany(x => x.SchoolComponents);
        }
    }
}
