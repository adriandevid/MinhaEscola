using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Classs
{
    [HttpDelete("class/{Id}")]
    [Authorize]
    public class RemoveEndPoint : Endpoint<RemoveClassRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public RemoveEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(RemoveClassRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
