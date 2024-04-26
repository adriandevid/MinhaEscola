using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.School.Interfaces;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School
{
    [HttpGet("/school/{Id}")]
    [Authorize]
    public class GetSchoolByIdEndPoint : Endpoint<GetSchoolByIdRequest>
    {
        private readonly ISchoolQueries _schoolQueries;
        public GetSchoolByIdEndPoint(ISchoolQueries schoolQueries)
        {
            _schoolQueries = schoolQueries;
        }

        public override async Task HandleAsync(GetSchoolByIdRequest req, CancellationToken ct)
        {
            await SendAsync(await _schoolQueries.GetSchoolById(req.Id));
        }
    }
}
