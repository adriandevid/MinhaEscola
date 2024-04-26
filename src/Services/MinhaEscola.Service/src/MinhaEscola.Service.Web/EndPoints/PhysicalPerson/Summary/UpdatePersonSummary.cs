using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson.Summary
{
    public class UpdatePersonSummary : Summary<UpdatePersonEndPoint>
    {
        public UpdatePersonSummary()
        {
            Summary = "Update a person";
            Description = "This school what have aproved";
            ExampleRequest = new UpdatePhysicalPersonRequest();
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
