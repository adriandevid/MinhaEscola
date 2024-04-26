using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge.Summary
{
    public class UpdateKnowledgeAreaSummary : Summary<UpdateKnowledgeAreaEndPoint>
    {
        public UpdateKnowledgeAreaSummary()
        {
            Summary = "Update a knowledgearea";
            Description = "Update a knowledgearea";
            ExampleRequest = new UpdateKnowledgeAreaRequest()
            {
                Id= 1,
                Name = "name",
                Description = "name",
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
