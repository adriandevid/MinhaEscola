using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Stage
{
    [HttpPut("/stage/")]
    [Authorize]
    public class UpdateStageEndPoint : Endpoint<UpdateStageRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateStageEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }


        public override async Task HandleAsync(UpdateStageRequest req, CancellationToken cancellationToken) 
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
