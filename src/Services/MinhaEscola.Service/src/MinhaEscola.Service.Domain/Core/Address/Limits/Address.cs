using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Core.Address.Events;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Core.Address.Limits
{
    public class Address : Entity, IAggregateRoot
    {
        public Address()
        {

        }

        public Address(string street, string cep, string neighborhood, long zoneId)
        {
            Street = street;
            CEP = cep;
            Neighborhood = neighborhood;
            ZoneId = zoneId;

            AppendEvent(new CreatedAddressEvent(street, cep, neighborhood, zoneId));
        }

        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public long ZoneId { get; set; }
        public Zone Zone { get; set; }
        public List<PhysicalPerson.Limits.PhysicalPerson> PhysicalPersons { get; set; }
        public List<School> Schools { get; set; }

        public void Update(string street, string cep, string neighborhood, long zoneId)
        {
            Street = street;
            CEP = cep;
            Neighborhood = neighborhood;
            ZoneId = zoneId;

            AppendEvent(new UpdatedAddressEvent(street, cep, neighborhood, zoneId));
        }
    }
}
