using MediatR;
using MinhaEscola.Service.Application.UseCases.Address.Requests;
using MinhaEscola.Service.Application.UseCases.Base.Request;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Board.School.ValueObject;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public class CreateSchoolRequest : Request, IRequest<ApiResponse>
    {
        public string Name { get; set; }
        public string NameAbbreviated { get; set; }
        public SituationOperation SituationOfOperationId { get; set; }
        public DepencyAdministractive DependencyAdministrativeId { get; set; }
        public CategoryOfSchoolPrivated CategorySchoolPrivatedId { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public string CNPJ { get; set; }
        public string UserReference { get; set; }
        public long AgencyPublicId { get; set; }
        public AddressRequest Address { get; set; }
    }
}
