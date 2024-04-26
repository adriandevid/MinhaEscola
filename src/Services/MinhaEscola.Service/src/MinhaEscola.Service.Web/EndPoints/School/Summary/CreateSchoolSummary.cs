using FastEndpoints;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.School.Requests;
using MinhaEscola.Service.Domain.Board.School.ValueObject;

namespace MinhaEscola.Service.Web.EndPoints.School.Summary
{
    public class CreateSchoolSummary : Summary<CreateSchoolEndPoint>
    {
        public CreateSchoolSummary()
        {
            Summary = "Create a new school";
            Description = "This school what have aproved";
            ExampleRequest = new CreateSchoolRequest() { 
                Name = "Evangelino de azevedo",
                NameAbbreviated = "E E Evangelino de azevedo",
                SituationOfOperationId = SituationOperation.InActivity,
                DependencyAdministrativeId = DepencyAdministractive.Municipal,
                CategorySchoolPrivatedId= CategoryOfSchoolPrivated.Community,
                CNPJ = "00000000",
                AgencyPublicId = 1,
                UserReference = "",
                Address = new Application.UseCases.Address.Requests.AddressRequest()
                {
                    Street= "  sadasdas",
                    Neighborhood = "  sadasdasd",
                    CEP = "ssadasdasd",
                    ZoneId= 1,
                }
            };
            Response<ApiResponse>(200, "ok response with body", example: new ApiResponse());
            Response<ErrorResponse>(400, "validation failure");
            Response(404, "account not found");
        }
    }
}
