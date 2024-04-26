using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Discipline.Summary
{
    public class CreateDisciplineSummary : Summary<CreateDisciplineEndPoint>
    {
        public CreateDisciplineSummary()
        {
            Summary = "Create a new discipline";
            Description = "Create a new discipline";
            ExampleRequest = new CreateDisciplineRequest()
            {
                Name = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
