using FluentValidation;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Application.UseCases.School.Validations
{
    public class UpdateSchoolRequestValidation : AbstractValidator<UpdateSchoolRequest>
    {
        public UpdateSchoolRequestValidation()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.NameAbbreviated).NotEmpty();
            RuleFor(x => x.CNPJ).NotEmpty();
        }
    }
}
