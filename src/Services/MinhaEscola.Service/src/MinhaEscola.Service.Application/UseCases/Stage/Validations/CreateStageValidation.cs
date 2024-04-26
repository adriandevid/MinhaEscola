using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Application.UseCases.Stage.Validations
{
    public class CreateStageValidation : AbstractValidator<CreateStageRequest>
    {
        public CreateStageValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.LevelEducationId).NotEqual(0);
        }
    }
}
