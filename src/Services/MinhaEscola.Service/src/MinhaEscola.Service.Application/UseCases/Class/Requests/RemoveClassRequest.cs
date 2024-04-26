using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Class.Requests
{
    public class RemoveClassRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
    }
}
