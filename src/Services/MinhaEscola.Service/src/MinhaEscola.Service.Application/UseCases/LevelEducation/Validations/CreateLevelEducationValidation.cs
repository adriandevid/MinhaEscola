using FluentValidation;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;


namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Validations
{
    public class CreateLevelEducationValidation : AbstractValidator<CreateLevelEducationRequest>
    {
        public CreateLevelEducationValidation()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
