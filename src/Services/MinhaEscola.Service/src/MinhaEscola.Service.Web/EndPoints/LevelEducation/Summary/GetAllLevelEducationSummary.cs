using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation.Summary
{
    public class GetAllLevelEducationSummary : Summary<GetAllLevelEducationEndPoint>
    {
        public GetAllLevelEducationSummary()
        {
            Summary = "Get all level education";
            Description = "Get all level education";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
