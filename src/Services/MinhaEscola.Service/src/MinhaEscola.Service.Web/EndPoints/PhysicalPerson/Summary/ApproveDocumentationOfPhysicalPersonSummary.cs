using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson.Summary
{
    public class ApproveDocumentationOfPhysicalPersonSummary : Summary<ApproveDocumentationOfPhysicalPersonEndPoint>
    {
        public ApproveDocumentationOfPhysicalPersonSummary()
        {
            Summary = "Approve documentation";
            Description = "Approve a unic document!";
            ExampleRequest = new ApproveDocumentationOfPhysicalPersonRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
