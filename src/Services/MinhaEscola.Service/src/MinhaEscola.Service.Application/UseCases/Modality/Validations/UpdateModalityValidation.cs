using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Application.UseCases.Modality.Validations
{
    public class UpdateModalityValidation : AbstractValidator<UpdateModalityRequest>
    {
        public UpdateModalityValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Id).NotEqual(0);
        }
    }
}
