using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Modality.Summary
{
    public class UpdateModalitySummary : Summary<UpdateModalityEndPoint>
    {
        public UpdateModalitySummary()
        {
            Summary = "Update a modality";
            Description = "Update a modality";
            ExampleRequest = new UpdateModalityRequest()
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
