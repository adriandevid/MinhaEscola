using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Events;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Administractive.Discipline.Limits
{
    public class Discipline : Entity, IAggregateRoot
    {
        public Discipline()
        {

        }

        public Discipline(string name, long knowledgeId)
        {
            Name = name;
            KnowledgeAreaId = knowledgeId;
            AppendEvent(new CreatedDisciplineDomainEvent());
        }

        public long KnowledgeAreaId { get; set; }
        public string Name { get; set; }
        public List<DisciplineComponent> DisciplineComponents { get; set; }
        public KnowledgeArea.Limits.KnowledgeArea KnowledgeArea { get; set; }

        public void Update(string name)
        {
            Name = name;

            AppendEvent(new UpdateDisciplineDomainEvent());
        }
    }
}
