using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Modality
{
    [HttpPost("/modality/")]
    [Authorize]
    public class CreateModalityEndPoint : Endpoint<CreateModalityRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public CreateModalityEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(CreateModalityRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
