using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson
{
    [HttpPost("physical-person/{Id}/document/approve/{DocumentId}")]
    [Authorize]
    public class ApproveDocumentationOfPhysicalPersonEndPoint : Endpoint<ApproveDocumentationOfPhysicalPersonRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public ApproveDocumentationOfPhysicalPersonEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(ApproveDocumentationOfPhysicalPersonRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
