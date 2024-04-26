using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge
{
    [HttpPut("/knowledge-area/")]
    [Authorize]
    public class UpdateKnowledgeAreaEndPoint : Endpoint<UpdateKnowledgeAreaRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateKnowledgeAreaEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateKnowledgeAreaRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
