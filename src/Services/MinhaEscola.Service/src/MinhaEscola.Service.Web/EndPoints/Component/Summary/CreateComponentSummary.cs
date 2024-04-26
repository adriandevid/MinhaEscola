using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;
using MinhaEscola.Service.Domain.Base.EnumTypes;

namespace MinhaEscola.Service.Web.EndPoints.Component.Summary
{
    public class CreateComponentSummary : Summary<CreateComponentEndPoint>
    {
        public CreateComponentSummary()
        {
            Summary = "Create a new component";
            Description = "Create a new component";
            ExampleRequest = new CreateComponentRequest()
            {
                Name = "name",
                DenominationId = 1,
                TypeOrganization = TypeOrganization.School,
                StageId= 1,
                ModalityId= 1
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
