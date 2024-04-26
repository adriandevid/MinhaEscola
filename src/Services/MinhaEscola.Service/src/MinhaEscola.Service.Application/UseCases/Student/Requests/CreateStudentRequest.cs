
using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Student.Requests
{
    public class CreateStudentRequest : IRequest<ApiResponse>
    {
        public string? Name { get; set; }
        public int Year { get; set; }
        public long SchoolId { get; set; }
        public long PhysicalPersonId { get; set; }
        public string UserReference { get; set; }
        public string INEP { get; set; }
        public bool UseTransport { get; set; }
    }
}
