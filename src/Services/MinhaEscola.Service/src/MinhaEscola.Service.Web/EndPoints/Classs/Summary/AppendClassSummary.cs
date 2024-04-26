using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Class.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Classs.Summary
{
    public class AppendClassSummary : Summary<CreateEndPoint>
    {
        public AppendClassSummary()
        {
            Summary = "Append new class to school";
            Description = "Append new class";
            ExampleRequest = new CreateClassRequest()
            {
                SchoolId = 1,
                ComponentId = 1
            };
            Response(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
