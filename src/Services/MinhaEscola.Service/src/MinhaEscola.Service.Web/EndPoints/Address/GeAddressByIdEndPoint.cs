using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Address.Interfaces;
using MinhaEscola.Service.Application.UseCases.Address.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Address
{
    [HttpGet("address/{Id}")]
    [Authorize]
    public class GeAddressByIdEndPoint : Endpoint<GetAddressByIdRequest>
    {
        private readonly IAddressQueries _addressQueries;
        public GeAddressByIdEndPoint(IAddressQueries addressQueries) { 
            _addressQueries= addressQueries;
        }

        public override async Task HandleAsync(GetAddressByIdRequest req, CancellationToken cancellationToken) {
            await SendAsync(await _addressQueries.GetById(req.Id));
        }
    }
}
