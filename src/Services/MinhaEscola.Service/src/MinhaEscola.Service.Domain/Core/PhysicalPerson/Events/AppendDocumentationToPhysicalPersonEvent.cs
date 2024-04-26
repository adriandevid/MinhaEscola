using MediatR;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Core.PhysicalPerson.Events
{
    public class AppendDocumentationToPhysicalPersonEvent : IEvent
    {
        public AppendDocumentationToPhysicalPersonEvent()
        {

        }


        public long Id { get; set; }
    }
}
