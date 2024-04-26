using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Requests
{
    public class UpdateLevelEducationRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
