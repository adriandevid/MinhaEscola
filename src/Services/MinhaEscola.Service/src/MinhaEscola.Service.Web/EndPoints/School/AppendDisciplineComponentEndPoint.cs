using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpPost("/school/component-discipline")]
    [Authorize]
    public class AppendDisciplineComponentEndPoint : Endpoint<AppendDisciplineComponentRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public AppendDisciplineComponentEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(AppendDisciplineComponentRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
