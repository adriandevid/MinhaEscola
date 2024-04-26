using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Core.Affiliation.Limits
{
    public class Affiliation : Entity
    {
        public Affiliation()
        {

        }

        public long RelatedId { get; set; }
        public long PhysicalPersonId { get; set; }
        public long TypeAffiliationId { get; set; }

        //public Entities.PhysicalPerson.Limits.PhysicalPerson Related { get; set; }
        public TypeAffiliation TypeAffiliation { get; set; }
        //public Entities.PhysicalPerson.Limits.PhysicalPerson PhysicalPerson { get; set; }
    }
}
