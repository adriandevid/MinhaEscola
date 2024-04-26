using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge.Summary
{
    public class GetAllKnowledgeAreaSummary : Summary<GetAllKnowledgeAreaEndPoint>
    {
        public GetAllKnowledgeAreaSummary()
        {
            Summary = "Get all knowledgeArea";
            Description = "Get all knowledgeArea";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
