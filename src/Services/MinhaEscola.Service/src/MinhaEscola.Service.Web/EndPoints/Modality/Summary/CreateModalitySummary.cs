using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;
using MinhaEscola.Service.Application.UseCases.Stage.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Modality.Summary
{
    public class CreateModalitySummary : Summary<CreateModalityEndPoint>
    {
        public CreateModalitySummary()
        {
            Summary = "Create a new modality";
            Description = "Create a new modality";
            ExampleRequest = new CreateModalityRequest()
            {
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
