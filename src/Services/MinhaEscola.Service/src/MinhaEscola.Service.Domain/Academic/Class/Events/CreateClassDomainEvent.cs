using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Academic.Class;

public class CreateClassDomainEvent : IEvent
{
    public long Id { get; set; }
}
