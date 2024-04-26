using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Board.School.Events
{
    public class CreateSchoolComponentDomainEvent : IEvent
    {
        public long Id { get; set; }
        public long ComponentId { get; set; }
        public long SchoolId { get; set; }
        public string Name { get; set; }
    }
}
