using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class AppendSchoolComponentSummary : Summary<AppendSchoolComponentEndPoint>
    {
        public AppendSchoolComponentSummary()
        {
            Summary = "Append new component to school";
            Description = "Append new component to school";
            ExampleRequest = new AppendSchoolComponentRequest() { 
                SchoolId = 1,
                ComponentId= 1
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
