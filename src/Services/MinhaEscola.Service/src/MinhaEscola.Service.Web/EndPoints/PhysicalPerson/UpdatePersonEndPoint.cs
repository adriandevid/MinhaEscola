using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson
{
    [HttpPut("physical-person")]
    [Authorize]
    public class UpdatePersonEndPoint : Endpoint<UpdatePhysicalPersonRequest, ApiResponse>
    {
        private readonly IMediator _mediator;
        public UpdatePersonEndPoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task HandleAsync(UpdatePhysicalPersonRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
