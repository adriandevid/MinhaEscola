using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Discipline.Summary
{
    public class UpdateDisciplineSummary : Summary<UpdateDisciplineEndPoint>
    {
        public UpdateDisciplineSummary()
        {
            Summary = "Create a new discipline";
            Description = "Create a new discipline";
            ExampleRequest = new UpdateDisciplineRequest()
            {
                Id= 1,
                Name = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
