using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student.Summary
{
    class StudentSummary : Summary<CreateStudentEndPoint>
    {
        public StudentSummary()
        {
            Summary = "Create a student";
            Description = "Create a student and informations of physical person!";
            ExampleRequest = new CreateStudentRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
