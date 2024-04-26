using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Administractive.Discipline.Limits;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Board.School.Events;
using MinhaEscola.Service.Domain.Board.School.ValueObject;

namespace MinhaEscola.Service.Domain.Board.School.Limits
{
    public class DisciplineComponent : Entity
    {
        public DisciplineComponent() { }

        public DisciplineComponent(long componentId, long disciplineId, WorkLoad workload, long schoolId)
        {
            ComponentId = componentId;
            DisciplineId = disciplineId;
            WorkLoad = workload;
            SchoolId = schoolId;

            AppendEvent(new DisciplineComponentCreatedDomainEvent() { SchoolId = schoolId });
        }

        public long ComponentId { get; set; }
        public long DisciplineId { get; set; }
        public long SchoolId { get; set; }


        public WorkLoad WorkLoad { get; set; }
        public School School { get; set; }
        public Discipline Discipline { get; set; }
        public Component Component { get; set; }


        public void Update(WorkLoad workload) { 
            WorkLoad = workload;
        }

    }
}
