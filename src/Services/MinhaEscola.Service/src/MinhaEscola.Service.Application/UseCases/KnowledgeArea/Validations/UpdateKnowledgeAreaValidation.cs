using FluentValidation;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Validations
{
    public class UpdateKnowledgeAreaValidation : AbstractValidator<UpdateKnowledgeAreaRequest>
    {
        public UpdateKnowledgeAreaValidation()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
