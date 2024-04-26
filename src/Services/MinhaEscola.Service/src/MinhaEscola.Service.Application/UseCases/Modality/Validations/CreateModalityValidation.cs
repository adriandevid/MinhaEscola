using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Application.UseCases.Modality.Validations
{
    public class CreateModalityValidation : AbstractValidator<CreateModalityRequest>
    {
        public CreateModalityValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
