using FluentValidation;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Validations
{
    public class UpdateLevelEducationValidation : AbstractValidator<UpdateLevelEducationRequest>
    {
        public UpdateLevelEducationValidation()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
