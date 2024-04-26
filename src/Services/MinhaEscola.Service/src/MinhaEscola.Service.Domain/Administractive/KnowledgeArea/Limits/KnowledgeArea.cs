using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Limits;

namespace MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Limits
{
    public class KnowledgeArea : Entity, IAggregateRoot
    {
        public KnowledgeArea(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Discipline.Limits.Discipline> Discipline { get; set; }
    }
}
