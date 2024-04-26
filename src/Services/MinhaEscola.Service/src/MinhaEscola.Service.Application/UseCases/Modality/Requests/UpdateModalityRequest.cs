using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Modality.Requests
{
    public class UpdateModalityRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
