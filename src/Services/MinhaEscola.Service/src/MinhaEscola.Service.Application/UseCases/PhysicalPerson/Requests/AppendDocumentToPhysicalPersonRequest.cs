using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.PhysicalPerson.Requests
{
    public class AppendDocumentToPhysicalPersonRequest : IRequest<ApiResponse>
    {
        public long PhysicalPersonId { get; set; }
        public long AttachmentId { get; set; }
        public long TypeDocumentationId { get; set; }
        public bool DocumentationValid { get; set; }
    }
}
