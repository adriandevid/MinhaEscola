using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests
{
    public class ApproveDocumentationOfPhysicalPersonRequest : IRequest<ApiResponse>
    {
        public ApproveDocumentationOfPhysicalPersonRequest()
        {

        }

        public long Id { get; set; }
        public long DocumentId { get; set; }
    }
}
