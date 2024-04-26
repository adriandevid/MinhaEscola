using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Entitie.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Academic.Student.Limits;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Domain.Academic.Class.Limits
{
    public class Class : Entity, IAggregateRoot
    {
        public Class() { }

        public Class(long amountStudent, bool active, string denomination, long componentId, long year, long schoolId)
        {
            AmountStudent = amountStudent;
            Active = active;
            Denomination = denomination;
            ComponentId = componentId;
            Year = year;
            SchoolId = schoolId;
        }


        public long AmountStudent { get; set; }
        public bool Active { get; set; }
        public string Denomination { get; set; }
        public long ComponentId { get; set; }
        public long Year { get; set; }
        public long SchoolId { get; set; }
        public Component? Component { get; set; }
        public List<Enrollment>? Enrollees { get; set; }
        public List<Lesson> Lessons { get; set; }
        public School? School { get; set; }

        public void Update(long amountStudent, string denomination, long year)
        {
            AmountStudent = amountStudent;
            Denomination = denomination; ;
            Year = year;
        }
    }
}
