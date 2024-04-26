using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Validations
{
    public class UpdateDisciplineValidation : AbstractValidator<UpdateDisciplineRequest>
    {
        public UpdateDisciplineValidation()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
