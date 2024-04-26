using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson.Summary
{
    public class AppendDocumentSummary : Summary<AppendDocumentEndPoint>
    {
        public AppendDocumentSummary()
        {
            Summary = "Append document to physical person";
            Description = "This function append a new document to physical person!";
            ExampleRequest = new AppendDocumentToPhysicalPersonRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
