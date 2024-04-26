using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("/school/{schoolId}/component-discipline/{id}")]
    [Authorize]
    public class GetDisciplineComponentEndPoint : Endpoint<GetDisciplineComponentByIdRequest, ApiResponse>
    {
        private readonly ISchoolQueries _schoolQuery;

        public GetDisciplineComponentEndPoint(ISchoolQueries schoolQuery)
        {
            _schoolQuery= schoolQuery;
        }

        public override async Task HandleAsync(GetDisciplineComponentByIdRequest req, CancellationToken ct)
        {
            await SendAsync(await _schoolQuery.GetDisciplineComponent(req.SchoolId, req.Id));
        }
    }
}
