using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation
{
    [HttpGet("/level-education/")]
    [Authorize]
    public class GetAllLevelEducationEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly ILevelEducationQueries _query;
        public GetAllLevelEducationEndPoint(ILevelEducationQueries query) { 
            _query= query;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await _query.GetAll());
        }
    }
}
