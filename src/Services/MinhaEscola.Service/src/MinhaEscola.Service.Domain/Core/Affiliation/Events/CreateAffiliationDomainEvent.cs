using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Core.Affiliation.Events;
public class CreateAffiliationDomainEvent : IEvent
{
    public long Id { get; set; }
}
