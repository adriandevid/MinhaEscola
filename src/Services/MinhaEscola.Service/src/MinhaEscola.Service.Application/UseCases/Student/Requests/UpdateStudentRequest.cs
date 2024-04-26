using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEscola.Service.Application.UseCases.Student.Requests
{
    public class UpdateStudentRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public long SchoolId { get; set; }
        public string? Name { get; set; }
        public string? RegisterOfPhysicalPerson { get; set; }
        public string? RegisterGeneral { get; set; }
        public long PhysicalPersonId { get; set; }
        public string INEP { get; set; }
        public bool UseTransport { get; set; }
    }
}
