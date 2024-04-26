using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.Component.Requests;
using MinhaEscola.Service.Domain.Base.EnumTypes;

namespace MinhaEscola.Service.Web.EndPoints.Component.Summary
{
    public class UpdateComponentSummary : Summary<UpdateComponentEndPoint>
    {
        public UpdateComponentSummary()
        {
            Summary = "Update a component";
            Description = "Update a component";
            ExampleRequest = new UpdateComponentRequest()
            {
                Id= 1,
                Name = "name",
                DenominationId = 1,
                TypeOrganization = TypeOrganization.School,
                StageId = 1,
                ModalityId = 1
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
