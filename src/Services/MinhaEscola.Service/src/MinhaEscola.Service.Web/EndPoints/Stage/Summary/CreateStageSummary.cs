using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Discipline.Requests;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Stage.Summary
{
    public class CreateStageSummary : Summary<CreateStageEndPoint>
    {
        public CreateStageSummary()
        {
            Summary = "Create a new stage";
            Description = "Create a new stage";
            ExampleRequest = new CreateStageRequest()
            {
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
