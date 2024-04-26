using FluentValidation;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Application.UseCases.School.Validations
{
    public class AppendDisciplineComponentValidation : AbstractValidator<AppendDisciplineComponentRequest>
    {
        public AppendDisciplineComponentValidation()
        {
            RuleFor(x => x.ComponentId).NotEqual(0);
            RuleFor(x => x.DisciplineId).NotEqual(0);
        }
    }
}
