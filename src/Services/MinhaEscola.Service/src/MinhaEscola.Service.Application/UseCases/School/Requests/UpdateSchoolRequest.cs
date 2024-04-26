using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Request;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public class UpdateSchoolRequest : Request, IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAbbreviated { get; set; }
        public string CNPJ { get; set; }
    }
}
