using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Limits;
using MinhaEscola.Service.Domain.Administractive.Stage.Events;

namespace MinhaEscola.Service.Domain.Administractive.Stage.Limits
{
    public class Stage : Entity, IAggregateRoot
    {
        public Stage() {
            AppendEvent(new StageCreatedDomainEvent());
        }

        public string Description { get; set; }
        public long LevelEducationId { get; set; }
        public LevelEducation.Limits.LevelEducation LevelEducation { get; set; }
    }
}
