using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Modality.Summary
{
    public class GetAllModalitySummary : Summary<GetAllModalityEndPoint>
    {
        public GetAllModalitySummary()
        {
            Summary = "Get all modalities";
            Description = "Get all modalities";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
