using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Classs
{
    [HttpGet("class/user")]
    [Authorize]
    public class GetClassesOfSchoolByUserReferenceEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IClassQueries _queries;

        public GetClassesOfSchoolByUserReferenceEndPoint(IClassQueries classQueries)
        {
            _queries = classQueries;
        }

        public override async Task HandleAsync(CancellationToken cancellationToken) {
            await SendAsync(await _queries.GetClassesOfSchoolByUserReference());
        }
    }
}
