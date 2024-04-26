using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Web.EndPoints.School;

namespace MinhaEscola.Service.Web.EndPoints.Address.Summary
{
    public class GetAddressByIdSummary : Summary<GeAddressByIdEndPoint>
    {
        public GetAddressByIdSummary()
        {
            Summary = "Get a address by id!";
            Description = "Get a address by id!";
            ExampleRequest = new UpdateAddressRequest()
            {
                Id = 1,
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
