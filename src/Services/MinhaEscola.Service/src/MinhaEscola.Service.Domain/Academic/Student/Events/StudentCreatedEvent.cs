using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Academic.Student.Events
{
    public class StudentCreatedEvent : IEvent
    {
        public StudentCreatedEvent()
        {

        }

        public StudentCreatedEvent(long schoolId, long physicalPersonId, string inep, bool useTransport)
        {
            SchoolId = schoolId;
            PhysicalPersonId = physicalPersonId;
            INEP = inep;
            UseTransport = useTransport;
        }

        public long Id { get; set; }
        public long SchoolId { get; set; }
        public long PhysicalPersonId { get; set; }
        public string INEP { get; set; }
        public bool UseTransport { get; set; }
    }
}
