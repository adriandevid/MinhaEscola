using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Board.School.Events
{
    public class RemoveComponentSchoolDomainEvent : IEvent
    {
        public long Id { get; set; }
    }
}
