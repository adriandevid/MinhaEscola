using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;

namespace MinhaEscola.Service.Domain.Board.PublicAgency.Limits
{
    public class PublicAgency : Entity, IAggregateRoot
    {
        public PublicAgency()
        {

        }
        public string Description { get; set; }
        public List<School.Limits.School> Schools { get; set; }
    }
}
