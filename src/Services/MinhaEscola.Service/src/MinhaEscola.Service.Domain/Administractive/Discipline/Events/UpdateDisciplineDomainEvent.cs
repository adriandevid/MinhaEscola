using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Administractive.Discipline.Events
{
    public class UpdateDisciplineDomainEvent : IEvent
    {
        public long Id { get; set; }
    }
}
