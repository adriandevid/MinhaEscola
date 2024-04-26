using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Classs
{
    [HttpPut("class")]
    [Authorize]
    public class UpdateEndPoint : Endpoint<UpdateClassRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateClassRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
