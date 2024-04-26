using FluentValidation;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Application.UseCases.School.Validations
{
    public class CreateSchoolValidation : AbstractValidator<CreateSchoolRequest>
    {
        public CreateSchoolValidation()
        {
            RuleFor(x => x.CNPJ).NotEmpty();
            RuleFor(x => x.AgencyPublicId).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.NameAbbreviated).NotEmpty();
        }
    }
}
