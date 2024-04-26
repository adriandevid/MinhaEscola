using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Component
{
    [HttpPost("/component/")]
    [Authorize]
    public class CreateComponentEndPoint : Endpoint<CreateComponentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public CreateComponentEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(CreateComponentRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
