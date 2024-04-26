using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Component
{
    [HttpPut("/component/")]
    [Authorize]
    public class UpdateComponentEndPoint : Endpoint<UpdateComponentRequest, ApiResponse>    
    {
        private readonly IMediator _mediator;

        public UpdateComponentEndPoint(IMediator mediator) { 
            _mediator= mediator;
        }

        public override async Task HandleAsync(UpdateComponentRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
