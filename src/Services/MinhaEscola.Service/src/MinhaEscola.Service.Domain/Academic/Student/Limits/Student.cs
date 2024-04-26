using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Academic.Student.Events;
using MinhaEscola.Service.Domain.Academic.Student.ValueObject;
using MinhaEscola.Service.Domain.Board.School.Limits;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;

namespace MinhaEscola.Service.Domain.Academic.Student.Limits
{
    public class Student : Entity, IAggregateRoot
    {
        public Student() { }

        public Student(long schoolId, string inep, bool useTransport, long personId, string userReference)
        {
            SchoolId = schoolId;
            INEP = inep;
            UseTransport = useTransport;
            PhysicalPersonId = personId;
            UserReference = userReference;

            AppendEvent(new StudentCreatedEvent(schoolId, personId, INEP, useTransport));
        }

        public long SchoolId { get; set; }
        public long PhysicalPersonId { get; set; }
        public string INEP { get; set; }
        public bool UseTransport { get; set; }

        private List<Enrollment> _enrollment = new();

        public School School { get; set; }
        public PhysicalPerson PhysicalPerson { get; set; }
        public IReadOnlyList<Enrollment> Enrollment => _enrollment.AsReadOnly();

        public string UserReference { get; set; }

        private StatusOfStudent _status = StatusOfStudent.Waiting;
        public StatusOfStudent Status { get { return _status; } }

        public void Aprove()
        {
            _status = StatusOfStudent.Aproved;
        }

        public void Unapproved()
        {
            _status = StatusOfStudent.Unapproved;
        }


        public void AssignEnrolleee(Enrollment enrollment)
        {
            if (_enrollment.Any(x => x.Active == true))
                throw new InvalidOperationException("Exist a enrollment open!");

            _enrollment.Add(enrollment);
        }

        public void UpdateInformations(string? name, string? registerOfPhysicalPerson, string? registerGeneral)
        {
            PhysicalPerson.RegisterOfPhysicalPerson = registerOfPhysicalPerson;
            PhysicalPerson.RegisterGeneral = registerGeneral;
            PhysicalPerson.Name = name;
        }
    }
}
