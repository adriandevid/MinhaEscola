using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;

namespace MinhaEscola.Service.Domain.Administractive.Sex.Limits
{
    public class Sex : Entity, IAggregateRoot
    {
        public string Description { get; set; }
        public List<PhysicalPerson> PhysicalPersons { get; set; }
    }
}
