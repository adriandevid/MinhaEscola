using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;
using MinhaEscola.Service.Application.UseCases.Modality.Requests;

namespace MinhaEscola.Service.Web.EndPoints.LevelEducation.Summary
{
    public class CreateLevelEducationSummary : Summary<CreateLevelEducationEndPoint>
    {
        public CreateLevelEducationSummary()
        {
            Summary = "Create a new LevelEducation";
            Description = "Create a new LevelEducation";
            ExampleRequest = new CreateLevelEducationRequest()
            {
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
