using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Application.UseCases.School.Responses;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("school/{Id}/components/")]
    [Authorize]
    public class GetComponentsOfSchoolEndPoint : Endpoint<GetComponentsOfSchoolById, ApiResponse>
    {
        private readonly ISchoolQueries _schoolQueries;

        public GetComponentsOfSchoolEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }


        public async override Task HandleAsync(GetComponentsOfSchoolById request, CancellationToken ct)
        {
             await SendAsync(await _schoolQueries.GetComponentsOfSchoolById(request.Id));
        }
    }
}
