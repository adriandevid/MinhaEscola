using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Academic.Student.Limits
{
    public class Enrollment : Entity
    {
        public Enrollment()
        {

        }

        public Enrollment(long classId, long studentId, long year, DateTime dateEnrollee, bool active)
        {
            ClassId = classId;
            StudentId = studentId;
            Year = year;
            DateEnrollee = dateEnrollee;
            Active = active;
        }

        public long ClassId { get; set; }
        public long StudentId { get; set; }
        public long Year { get; set; }
        public DateTime DateEnrollee { get; set; }
        public bool Active { get; set; }
        public Class.Limits.Class Class { get; set; }
        public Student Student { get; set; }
    }
}
