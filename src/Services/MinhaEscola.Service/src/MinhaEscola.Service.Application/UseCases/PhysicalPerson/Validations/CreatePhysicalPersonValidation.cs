using FluentValidation;
using MinhaEscola.Service.Application.UseCases.Address.Validations;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Validations
{
    public class CreatePhysicalPersonValidation : AbstractValidator<CreatePhysicalPersonRequest>
    {
        public CreatePhysicalPersonValidation()
        {
            RuleFor(x => x.RegisterGeneral).NotEmpty();
            RuleFor(x => x.Year).NotEqual(0);
            RuleFor(x => x.RegisterOfPhysicalPerson).NotEmpty();
            RuleFor(x => x.ColorId).NotEqual(0);
            RuleFor(x => x.NationalityId).NotEqual(0);
            RuleFor(x => x.RegisterGeneral).NotEmpty();
            RuleFor(x => x.SexId).NotEqual(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotNull().SetValidator(new AddressValidation());
        }
    }
}
