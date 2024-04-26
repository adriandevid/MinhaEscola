using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;
using MinhaEscola.Service.Application.UseCases.LevelEducation.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge.Summary
{
    public class CreateKnowledgeAreaSummary : Summary<CreateKnowledgeAreaEndPoint>
    {
        public CreateKnowledgeAreaSummary()
        {
            Summary = "Create a new knowledgeArea";
            Description = "Create a new knowledgeArea";
            ExampleRequest = new CreateKnowledgeAreaRequest()
            {
                Name= "name",
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
