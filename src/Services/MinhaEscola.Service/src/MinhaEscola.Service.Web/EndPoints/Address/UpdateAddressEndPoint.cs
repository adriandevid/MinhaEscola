using MediatR;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.Address
{
    [HttpPut("api/v{version:apiVersion}/address/")]
    [Authorize]
    public class UpdateAddressEndPoint : Endpoint<UpdateAddressRequest, ApiResponse>
    {
        private readonly IMediator _mediator;

        public UpdateAddressEndPoint(IMediator mediator) { 
            _mediator= mediator;
        }

        public override async Task HandleAsync(UpdateAddressRequest req, CancellationToken ct)
        {
            await SendAsync(await _mediator.Send(req));
        }
    }
}
