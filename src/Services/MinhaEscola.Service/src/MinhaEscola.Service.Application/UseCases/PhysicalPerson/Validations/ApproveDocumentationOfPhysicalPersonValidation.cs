using FluentValidation;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Validations
{
    public class ApproveDocumentationOfPhysicalPersonValidation : AbstractValidator<ApproveDocumentationOfPhysicalPersonRequest>
    {
        public ApproveDocumentationOfPhysicalPersonValidation()
        {
            RuleFor(x => x.DocumentId).NotEqual(0);
            RuleFor(x => x.Id).NotEqual(0);
        }
    }
}
