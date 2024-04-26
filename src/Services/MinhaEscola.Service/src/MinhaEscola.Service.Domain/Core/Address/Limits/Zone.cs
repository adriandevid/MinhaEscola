using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;

namespace MinhaEscola.Service.Domain.Core.Address.Limits
{
    public class Zone : Entity, IAggregateRoot
    {
        public Zone()
        {

        }

        public string Description { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
