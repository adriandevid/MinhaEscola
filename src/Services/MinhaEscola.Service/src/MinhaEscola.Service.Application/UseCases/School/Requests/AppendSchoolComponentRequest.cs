using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public class AppendSchoolComponentRequest : IRequest<ApiResponse>
    {
        public long SchoolId { get; set; }
        public long ComponentId { get; set; }
    }
}
