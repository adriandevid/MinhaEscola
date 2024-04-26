using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation
{
    [HttpPut("/level-education/")]
    [Authorize]
    public class UpdateLevelEducationEndPoint : Endpoint<UpdateLevelEducationRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateLevelEducationEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdateLevelEducationRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
