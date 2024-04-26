using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Student.Requests
{
    public class AppendEnrollmentRequest : IRequest<ApiResponse>
    {
        public long ClassId { get; set; }
        public long StudentId { get; set; }
        public long Year { get; set; }
        public DateTime DateEnrollee { get; set; }
        public bool Active { get; set; }
    }
}
