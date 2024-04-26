using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Validations
{
    public class CreateDisciplineValidation : AbstractValidator<CreateDisciplineRequest>
    {
        public CreateDisciplineValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.KnowledgeAreaId).NotEqual(0);
        }
    }
}
