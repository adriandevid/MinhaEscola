using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Discipline
{
    [HttpPut("/discipline/")]
    [Authorize]
    public class UpdateDisciplineEndPoint : Endpoint<UpdateDisciplineRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public UpdateDisciplineEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateDisciplineRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
