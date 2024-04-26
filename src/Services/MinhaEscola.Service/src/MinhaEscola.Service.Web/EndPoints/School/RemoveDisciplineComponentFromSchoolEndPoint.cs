using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpDelete("/school/{schoolId}/component-discipline/{id}")]
    [Authorize]
    public class RemoveDisciplineComponentFromSchoolEndPoint : Endpoint<RemoveDisciplineComponentFromSchoolRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public RemoveDisciplineComponentFromSchoolEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(RemoveDisciplineComponentFromSchoolRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
