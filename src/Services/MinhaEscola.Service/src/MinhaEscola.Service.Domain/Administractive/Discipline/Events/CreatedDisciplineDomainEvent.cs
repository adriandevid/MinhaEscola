using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Administractive.Discipline.Events
{
    public class CreatedDisciplineDomainEvent : IEvent
    {
        public long Id { get; set; }
    }
}
