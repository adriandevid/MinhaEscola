using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpPut("/school")]
    [Authorize]
    public class UpdateSchoolEndPoint : Endpoint<UpdateSchoolRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public UpdateSchoolEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateSchoolRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
