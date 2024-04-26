using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Denomination
{
    [HttpGet("/denomination/")]
    // [Authorize]
    [AllowAnonymous]
    public class GetAllDenominationEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IComponentQueries _componentQueries;

        public GetAllDenominationEndPoint(IComponentQueries componentQueries)
        {
            _componentQueries= componentQueries;
        }


        public override async Task HandleAsync(CancellationToken cancellationToken) {
            await SendAsync(await _componentQueries.GetAllDenominations());
        }
    }
}
