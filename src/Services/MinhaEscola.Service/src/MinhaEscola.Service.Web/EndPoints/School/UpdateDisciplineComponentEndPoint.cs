using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpPut("/school/component-discipline")]
    [Authorize]
    public class UpdateDisciplineComponentEndPoint : Endpoint<UpdateDisciplineComponentFromSchoolRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateDisciplineComponentEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(UpdateDisciplineComponentFromSchoolRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
