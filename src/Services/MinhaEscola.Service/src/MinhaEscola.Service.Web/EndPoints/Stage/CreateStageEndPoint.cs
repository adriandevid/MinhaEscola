using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Stage
{
    [HttpPost("/stage/")]
    [Authorize]
    public class CreateStageEndPoint : Endpoint<CreateStageRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        private readonly IWebSocketService _websocketService;

        public CreateStageEndPoint(IMediator mediator, IWebSocketService webSocketService)
        {
            _mediator = mediator;
            _websocketService = webSocketService;
        }

        public override async Task HandleAsync(CreateStageRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
