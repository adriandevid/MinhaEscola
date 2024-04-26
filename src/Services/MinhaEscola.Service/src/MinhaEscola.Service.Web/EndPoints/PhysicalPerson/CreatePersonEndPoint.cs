using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson
{
    [HttpPost("physical-person")]
    [Authorize]
    public class CreatePersonEndPoint : Endpoint<CreatePhysicalPersonRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public CreatePersonEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(CreatePhysicalPersonRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
