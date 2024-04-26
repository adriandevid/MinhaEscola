using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests;

namespace MinhaEscola.Service.Web.EndPoints.PhysicalPerson.Summary
{
    public class CreatePersonSummary : Summary<CreatePersonEndPoint>
    {
        public CreatePersonSummary()
        {
            Summary = "Create a new person";
            Description = "This school what have aproved";
            ExampleRequest = new CreatePhysicalPersonRequest() { 
                Name= "Adrian Josefino",
                Year = 2001,
                RegisterOfPhysicalPerson = "08397608508",
                RegisterGeneral = "00000000",
                SexId = 1,
                ColorId= 1,
                NationalityId = 1,
                Address = new Application.UseCases.Address.Requests.AddressRequest() { 
                    CEP = "Sei la onde",
                    Street = "Av. Etelvino Alves de lima",
                    Neighborhood = "Bairro",
                    ZoneId= 1
                }
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
