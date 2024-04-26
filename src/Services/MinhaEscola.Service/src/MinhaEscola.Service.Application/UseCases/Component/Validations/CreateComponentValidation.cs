using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Component.Requests;

namespace MinhaEscola.Service.Application.UseCases.Component.Validations
{
    public class CreateComponentValidation : AbstractValidator<CreateComponentRequest>
    {
        public CreateComponentValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DenominationId).NotEqual(0);
            RuleFor(x => x.ModalityId).NotEqual(0);
            RuleFor(x => x.StageId).NotEqual(0);
            RuleFor(x => x.TypeOrganization).NotNull();
        }
    }
}
