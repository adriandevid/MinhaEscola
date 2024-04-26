using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Classs
{
    [HttpPost("class")]
    [Authorize]
    public class CreateEndPoint : Endpoint<CreateClassRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public CreateEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(CreateClassRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
