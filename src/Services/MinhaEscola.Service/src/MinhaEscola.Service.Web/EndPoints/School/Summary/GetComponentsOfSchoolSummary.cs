using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class GetComponentsOfSchoolSummary : Summary<GetComponentsOfSchoolEndPoint>
    {
        public GetComponentsOfSchoolSummary()
        {
            Summary = "Get components from school";
            Description = "List components";
            ExampleRequest = new ApiResponse();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
