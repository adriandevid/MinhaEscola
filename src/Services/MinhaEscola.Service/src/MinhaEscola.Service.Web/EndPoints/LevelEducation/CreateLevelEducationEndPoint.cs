using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation
{
    [HttpPost("/level-education/")]
    [Authorize]
    public class CreateLevelEducationEndPoint : Endpoint<CreateLevelEducationRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public CreateLevelEducationEndPoint(IMediator mediator)
        {
            _mediator= mediator;
        }

        public override async Task HandleAsync(CreateLevelEducationRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
