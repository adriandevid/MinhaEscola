using FluentValidation;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Application.UseCases.School.Validations
{
    public class AppendSchoolComponentValidation : AbstractValidator<AppendSchoolComponentRequest>
    {
        public AppendSchoolComponentValidation() {
            RuleFor(x => x.ComponentId).NotEqual(0);
            RuleFor(x => x.SchoolId).NotEqual(0);
        }
    }
}
