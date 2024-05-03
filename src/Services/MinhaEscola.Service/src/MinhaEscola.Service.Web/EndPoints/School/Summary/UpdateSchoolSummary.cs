using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class UpdateSchoolSummary : Summary<UpdateSchoolEndPoint>
    {
        public UpdateSchoolSummary()
        {
            Summary = "Create a new school";
            Description = "This school what have aproved";
            ExampleRequest = new ApiResponse();
            Response<ApiResponse>(200, "ok response with body");
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
