using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Stage.Summary
{
    public class UpdateStageSummary : Summary<UpdateStageEndPoint>
    {
        public UpdateStageSummary()
        {
            Summary = "update stage";
            Description = "update stage";
            ExampleRequest = new UpdateStageRequest()
            {
                Id= 1,
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
