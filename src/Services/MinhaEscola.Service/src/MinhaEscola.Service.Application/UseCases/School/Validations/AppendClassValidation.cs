using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Class.Requests;

namespace MinhaEscola.Service.Application.UseCases.School.Validations
{
    public class AppendClassValidation : AbstractValidator<CreateClassRequest>
    {
        public AppendClassValidation()
        {
            RuleFor(x => x.AmountStudent).NotEqual(0);
            RuleFor(x => x.Active).NotNull();
            RuleFor(x => x.ComponentId).NotEqual(0);
            RuleFor(x => x.Denomination).NotEmpty().NotNull();
            RuleFor(x => x.Year).NotNull();
            RuleFor(x => x.SchoolId).NotNull().NotEqual(0);
        }
    }
}
