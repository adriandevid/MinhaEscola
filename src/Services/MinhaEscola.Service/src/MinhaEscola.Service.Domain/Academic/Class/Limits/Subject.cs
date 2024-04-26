using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Academic.Class.Limits;
public class Subject : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
