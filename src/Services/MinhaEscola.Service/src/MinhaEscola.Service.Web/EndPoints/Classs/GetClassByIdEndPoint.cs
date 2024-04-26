using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Interfaces;
using MinhaEscola.Service.Application.UseCases.Class.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Classs
{
    [HttpGet("class/{Id}")]
    [Authorize]
    public class GetClassByIdEndPoint : Endpoint<GetClassByIdRequest, ApiResponse>
    {
        private readonly IClassQueries _queries;

        public GetClassByIdEndPoint(IClassQueries classQueries)
        {
            _queries = classQueries;
        }

        public override async Task HandleAsync(GetClassByIdRequest req, CancellationToken cancellationToken)
        {
            await SendAsync(await _queries.GetById(req.Id));
        }
    }
}
