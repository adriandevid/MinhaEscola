using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student.Summary
{
    public class AppendEnrollmentSummary : Summary<AppendEnrollmentEndPoint>
    {
        public AppendEnrollmentSummary()
        {
            Summary = "Create a new enrollment";
            Description = "Create a enrollment to student";
            ExampleRequest = new AppendEnrollmentRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
