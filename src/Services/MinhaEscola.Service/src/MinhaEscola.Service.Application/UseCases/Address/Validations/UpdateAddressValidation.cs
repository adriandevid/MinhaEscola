using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Address.Requests;

namespace MinhaEscola.Service.Application.UseCases.Address.Validations
{
    internal class UpdateAddressValidation : AbstractValidator<UpdateAddressRequest>
    {
        public UpdateAddressValidation()
        {
            RuleFor(x => x.Id).Equal(0);
            RuleFor(x => x.CEP).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.Neighborhood).NotEmpty();
            RuleFor(x => x.ZoneId).NotEqual(0);
        }
    }
}
