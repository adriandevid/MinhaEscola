using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;

namespace MinhaEscola.Service.Domain.Administractive.Modality.Limits
{
    public class Modality : Entity, IAggregateRoot
    {
        public Modality() { }

        public string Description { get; set; }
    }
}
