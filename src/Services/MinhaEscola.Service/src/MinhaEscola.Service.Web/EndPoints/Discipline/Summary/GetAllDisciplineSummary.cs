using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Web.EndPoints.Discipline.Summary
{
    public class GetAllDisciplineSummary : Summary<GetAllDisciplineEndPoint>
    {
        public GetAllDisciplineSummary()
        {
            Summary = "Get all discipline";
            Description = "Get all discipline";
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
