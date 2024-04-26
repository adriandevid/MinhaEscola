using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Requests
{
    public class CreateLevelEducationRequest : IRequest<ApiResponse>
    {
        public string Description { get; set; }
    }
}
