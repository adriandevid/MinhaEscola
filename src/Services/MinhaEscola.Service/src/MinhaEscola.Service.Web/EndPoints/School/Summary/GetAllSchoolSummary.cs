using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class GetAllSchoolSummary : Summary<GetAllSchoolEndPoint>
    {
        public GetAllSchoolSummary()
        {
            Summary = "Get a list of school's";
            Description = "Return list of school's";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
