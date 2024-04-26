using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Core.Affiliation.Limits
{
    public class TypeAffiliation : Entity
    {
        public TypeAffiliation()
        {

        }

        public string Description { get; set; }
        public List<Affiliation> Affiliations { get; set; }
    }
}
