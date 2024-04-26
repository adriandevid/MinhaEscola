using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.Stage.Summary
{
    public class GetAllStageSummary : Summary<GetAllStageEndPoint>
    {
        public GetAllStageSummary()
        {
            Summary = "Get All stages";
            Description = "Get All Stages";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
