using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Component.Requests;

namespace MinhaEscola.Service.Application.UseCases.Component.Validations
{
    public class UpdateComponentValidation : AbstractValidator<UpdateComponentRequest>
    {
        public UpdateComponentValidation() 
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DenominationId).NotEqual(0);
            RuleFor(x => x.ModalityId).NotEqual(0);
            RuleFor(x => x.StageId).NotEqual(0);
            RuleFor(x => x.TypeOrganization).NotNull();
        }
    }
}
