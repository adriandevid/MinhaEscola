using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Academic.Class.Limits;
public class Lesson : Entity
{
    public string? Description { get; set; }
    public double Duration { get; set; }
    public DateTime Date { get; set; }

    public long ClassId { get; set; }
    public Class Class { get; set; }

    // public List<Frequency> Frequencies { get; set; }
    public List<Subject> Subjects { get; set; }
}
