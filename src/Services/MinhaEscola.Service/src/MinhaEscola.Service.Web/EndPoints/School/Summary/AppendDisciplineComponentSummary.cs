using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class AppendDisciplineComponentSummary : Summary<AppendDisciplineComponentEndPoint>
    {
        public AppendDisciplineComponentSummary()
        {
            Summary = "Append new discipline to school with component defined";
            Description = "Append new discipline to school with component defined";
            ExampleRequest = new AppendDisciplineComponentRequest()
            {
                SchoolId = 1,
                ComponentId = 1,
                DisciplineId= 1,
                WeekHours= 1,
                WeeklyClass= 1,
                AnnualClass= 100
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
