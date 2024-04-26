using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.Address.Summary
{
    public class UpdateAddressSummary : Summary<UpdateAddressEndPoint>
    {
        public UpdateAddressSummary()
        {
            Summary = "Update a address";
            Description = "This procidure execute of update a address!";
            ExampleRequest = new UpdateAddressRequest()
            {
                Id= 1,
                CEP = "Sei la onde",
                Street = "Av. Etelvino Alves de lima",
                Neighborhood = "Bairro",
                ZoneId = 1
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
