using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Modality
{
    [HttpPut("/modality/")]
    [Authorize]
    public class UpdateModalityEndPoint : Endpoint<UpdateModalityRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateModalityEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateModalityRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
