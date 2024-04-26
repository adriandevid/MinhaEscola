using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("school/user")]
    [Authorize]
    public class GetSchoolByUserReferenceEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetSchoolByUserReferenceEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries= schoolQueries;
        }

        public override async Task HandleAsync(CancellationToken cancellationToken) {
            await SendAsync(await _schoolQueries.GetByUserReference());
        }
    }
}
