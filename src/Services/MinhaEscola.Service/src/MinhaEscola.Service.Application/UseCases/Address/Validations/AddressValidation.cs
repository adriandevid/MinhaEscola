using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Application.UseCases.Address.Validations
{
    public class AddressValidation : AbstractValidator<AddressRequest>
    {
        public AddressValidation()
        {
            RuleFor(x => x.CEP).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.Neighborhood).NotEmpty();
            RuleFor(x => x.ZoneId).NotEqual(0);
        }
    }
}
