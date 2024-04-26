using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("school/user/components")]
    [Authorize]
    public class GetComponentsByUserReferenceEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetComponentsByUserReferenceEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries= schoolQueries;
        }

        public override async Task HandleAsync(CancellationToken cancellationToken) {
            await SendAsync(await _schoolQueries.GetComponentsOfSchoolByUserReference());
        }
    }
}
