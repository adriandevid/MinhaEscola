using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Application.UseCases.Stage.Validations
{
    public class UpdateStageValidation : AbstractValidator<UpdateStageRequest>
    {
        public UpdateStageValidation()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.LevelEducationId).NotEqual(0);
        }
    }
}
