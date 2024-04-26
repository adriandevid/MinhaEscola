using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public class RemoveDisciplineComponentFromSchoolRequest : IRequest<ApiResponse>
    {
        public long SchoolId { get; set; }
        public long Id { get; set; }
    }
}
