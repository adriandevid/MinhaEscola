using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Modality
{
    [HttpGet("/modality/")]
    [Authorize]
    public class GetAllModalityEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IModalityQueries _modalityQueries;

        public GetAllModalityEndPoint(IModalityQueries modalityQueries)
        {
            _modalityQueries= modalityQueries;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await _modalityQueries.GetAll());
        }
    }
}
