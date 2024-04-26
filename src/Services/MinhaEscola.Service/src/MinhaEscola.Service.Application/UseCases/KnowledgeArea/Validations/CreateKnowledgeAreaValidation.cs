using FluentValidation;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Validations
{
    public class CreateKnowledgeAreaValidation : AbstractValidator<CreateKnowledgeAreaRequest>
    {
        public CreateKnowledgeAreaValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
