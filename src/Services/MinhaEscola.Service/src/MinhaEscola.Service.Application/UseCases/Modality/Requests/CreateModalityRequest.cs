using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Modality.Requests
{
    public class CreateModalityRequest : IRequest<ApiResponse>
    {
        public string Description { get; set; }
    }
}
