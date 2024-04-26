using MediatR;
using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Core.PhysicalPerson.Events
{
    public class CreatedPhysicalPersonEvent : IEvent
    {
        public CreatedPhysicalPersonEvent()
        {

        }

        public CreatedPhysicalPersonEvent(string? name, int year, string? registerOfPhysicalPerson, long sexId, long colorId, string? registerGeneral, long nationalityId)
        {
            Name = name;
            Year = year;
            RegisterOfPhysicalPerson = registerOfPhysicalPerson;
            SexId = sexId;
            ColorId = colorId;
            RegisterGeneral = registerGeneral;
            NationalityId = nationalityId;
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? RegisterOfPhysicalPerson { get; set; }
        public long AddressId { get; set; }
        public long SexId { get; set; }
        public long ColorId { get; set; }
        public string? RegisterGeneral { get; set; }
        public long NationalityId { get; set; }

    }
}
