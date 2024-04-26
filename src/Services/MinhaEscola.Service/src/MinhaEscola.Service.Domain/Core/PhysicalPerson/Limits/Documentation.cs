using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.ValueObject;

namespace MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits
{
    public class Documentation : Entity, IAggregateRoot
    {
        public Documentation() { }

        public Documentation(long physicalPersonId, long attachmentId, TypeDocument typeDocumentationId)
        {
            PhysicalPersonId = physicalPersonId;
            AttachmentId = attachmentId;
            TypeDocumentationId = typeDocumentationId;
        }

        public Documentation(long attachmentId, TypeDocument typeDocumentationId)
        {
            AttachmentId = attachmentId;
            TypeDocumentationId = typeDocumentationId;
        }

        public long PhysicalPersonId { get; set; }
        public long AttachmentId { get; set; }
        public bool DocumentationValid { get; set; }

        public TypeDocument TypeDocumentationId { get; set; }
        public PhysicalPerson PhysicalPerson { get; set; }

        public void ValidateDocumentation()
        {
            DocumentationValid = true;
        }

        public void InvalidateDocumentation()
        {
            DocumentationValid = false;
        }
    }
}
