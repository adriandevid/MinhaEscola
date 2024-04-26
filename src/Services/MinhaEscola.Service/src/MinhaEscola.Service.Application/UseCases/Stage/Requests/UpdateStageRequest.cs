using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Stage.Requests
{
    public class UpdateStageRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long LevelEducationId { get; set; }
    }
}
