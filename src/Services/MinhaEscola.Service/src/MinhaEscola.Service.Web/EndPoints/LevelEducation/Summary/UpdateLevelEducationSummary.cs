using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation.Summary
{
    public class UpdateLevelEducationSummary : Summary<UpdateLevelEducationEndPoint>
    {
        public UpdateLevelEducationSummary()
        {
            Summary = "Update a new LevelEducation";
            Description = "Update a new LevelEducation";
            ExampleRequest = new UpdateLevelEducationRequest()
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
