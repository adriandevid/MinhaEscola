using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Board.School.Events;

namespace MinhaEscola.Service.Domain.Board.School.Limits
{
    public class SchoolComponent : Entity
    {
        public SchoolComponent() { }

        public SchoolComponent(long schoolId, long componentId)
        {
            SchoolId = schoolId;
            ComponentId = componentId;

            AppendEvent(new SchoolComponentCreatedDomainEvent() { SchoolId = schoolId });
        }

        public long SchoolId { get; set; }
        public long ComponentId { get; set; }

        public School School { get; set; }
        public Component Component { get; set; }
    }
}
