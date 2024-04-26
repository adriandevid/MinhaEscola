using MinhaEscola.Service.Domain.Core.Address.Limits;
using System.Runtime.ConstrainedExecution;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Core.Address.Events
{
    public class UpdatedAddressEvent : IEvent
    {
        public UpdatedAddressEvent()
        {

        }

        public UpdatedAddressEvent(string street, string cep, string neighborhood, long zoneId)
        {
            Street = street;
            CEP = cep;
            Neighborhood = neighborhood;
            ZoneId = zoneId;
        }

        public long Id { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public long ZoneId { get; set; }

    }
}
