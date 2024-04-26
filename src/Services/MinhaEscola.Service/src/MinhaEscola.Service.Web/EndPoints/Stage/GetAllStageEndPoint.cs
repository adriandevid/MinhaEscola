using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Stage
{
    [Authorize]
    [HttpGet("/stage/")]
    public class GetAllStageEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IStageQueries _stageQueries;

        public GetAllStageEndPoint(IStageQueries stageQueries)
        {
            _stageQueries = stageQueries;
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            await SendAsync(await _stageQueries.GetAll());
        }
    }
}
