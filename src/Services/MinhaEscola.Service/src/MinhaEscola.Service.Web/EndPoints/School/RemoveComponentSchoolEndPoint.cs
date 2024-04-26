using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpDelete("/school/{schoolId}/school-component/{id}")]
    [Authorize]
    public class RemoveComponentSchoolEndPoint : Endpoint<RemoveComponentSchoolRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public RemoveComponentSchoolEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(RemoveComponentSchoolRequest request, CancellationToken token) {
            await SendAsync(await _mediator.Send(request));
        }
    }
}
