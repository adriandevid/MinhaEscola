using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Administractive.Stage.Events
{
    public class StageCreatedDomainEvent : IEvent
    {
        public long Id { get; set; }
    }
}
