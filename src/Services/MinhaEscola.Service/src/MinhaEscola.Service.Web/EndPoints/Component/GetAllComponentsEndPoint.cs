using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Component
{
    [HttpGet("component/")]
    // [Authorize]
    [AllowAnonymous]
    public class GetAllComponentsEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IComponentQueries _queries;

        public GetAllComponentsEndPoint(IComponentQueries queries)
        {
            _queries= queries;
        }

        public override async Task HandleAsync(CancellationToken cancellationToken) {
            await SendAsync(await _queries.GetAll());
        }
    }
}
