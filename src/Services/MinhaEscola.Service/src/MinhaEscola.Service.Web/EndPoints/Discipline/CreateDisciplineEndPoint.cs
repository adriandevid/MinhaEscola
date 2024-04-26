using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Discipline
{
    [HttpPost("/discipline/")]
    [Authorize]
    public class CreateDisciplineEndPoint : Endpoint<CreateDisciplineRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public CreateDisciplineEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(CreateDisciplineRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
