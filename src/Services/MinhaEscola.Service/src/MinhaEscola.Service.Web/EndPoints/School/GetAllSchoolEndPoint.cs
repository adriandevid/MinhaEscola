using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("/school/")]
    [Authorize]
    public class GetAllSchoolEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly ISchoolQueries _schoolQueries;
        public GetAllSchoolEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await _schoolQueries.GetAll());
        }
    }
}
