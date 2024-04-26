using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Board.School.Events
{
    public class SchoolComponentCreatedDomainEvent : IEvent
    {
        public long Id { get; set; }
        public long SchoolId { get; set; }
    }
}
