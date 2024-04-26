using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Stage.Requests
{
    public class CreateStageRequest : IRequest<ApiResponse>
    {
        public string Description { get; set; }
        public long LevelEducationId { get; set; }
    }
}
