using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Academic.Class.Limits;
public class Frequency : Entity
{
    public string Description { get; set; }
    public bool ItPresent { get; set; }
    public DateTime Date { get; set; }
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
