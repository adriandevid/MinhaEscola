using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Student.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Student.Summary
{
    public class UpdateStudentSummary : Summary<UpdateStudentEndPoint>
    {
        public UpdateStudentSummary()
        {
            Summary = "update a student";
            Description = "update a student and informations of physical person!";
            ExampleRequest = new CreateStudentRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
