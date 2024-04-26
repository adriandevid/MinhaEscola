using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;

namespace MinhaEscola.Service.Domain.Administractive.LevelEducation.Limits
{
    public class LevelEducation : Entity, IAggregateRoot
    {
        public LevelEducation()
        {

        }

        public string Description { get; set; }

        public List<Stage.Limits.Stage> Stages { get; set; }
    }
}
