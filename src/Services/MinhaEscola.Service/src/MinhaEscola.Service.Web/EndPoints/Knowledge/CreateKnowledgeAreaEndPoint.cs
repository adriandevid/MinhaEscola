using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge
{
    [HttpPost("/knowledge-area/")]
    [Authorize]
    public class CreateKnowledgeAreaEndPoint : Endpoint<CreateKnowledgeAreaRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public CreateKnowledgeAreaEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(CreateKnowledgeAreaRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
