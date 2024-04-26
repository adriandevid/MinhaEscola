using MediatR;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests
{
    public class CreatePhysicalPersonRequest : IRequest<ApiResponse>
    {
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? RegisterOfPhysicalPerson { get; set; }
        public long SexId { get; set; }
        public long ColorId { get; set; }
        public string? RegisterGeneral { get; set; }
        public long NationalityId { get; set; }

        public AddressRequest Address { get; set; }
    }
}
