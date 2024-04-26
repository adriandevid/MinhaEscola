using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("school/{Id}/component-discipline")]
    [Authorize]
    public class GetDisciplinesOfSchoolEndPoint : Endpoint<GetDisciplinesSchoolRequest, ApiResponse>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetDisciplinesOfSchoolEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }


        public async override Task HandleAsync(GetDisciplinesSchoolRequest request, CancellationToken ct)
        {
             await SendAsync(await _schoolQueries.GetDisciplinesOfSchoolById(request.Id));
        }
    }
}
