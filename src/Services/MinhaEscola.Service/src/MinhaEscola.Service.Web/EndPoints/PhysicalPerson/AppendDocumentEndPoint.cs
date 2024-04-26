using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson
{
    [HttpPost("physical-person/document")]
    [Authorize]
    public class AppendDocumentEndPoint : Endpoint<AppendDocumentToPhysicalPersonRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public AppendDocumentEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(AppendDocumentToPhysicalPersonRequest req, CancellationToken cancellationToken) {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
