using MediatR;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Core.PhysicalPerson.Events
{
    public class AppendAffiliationToPhysicalPersonEvent : IEvent
    {
        public AppendAffiliationToPhysicalPersonEvent()
        {

        }
        public long Id { get; set; }
    }
}
