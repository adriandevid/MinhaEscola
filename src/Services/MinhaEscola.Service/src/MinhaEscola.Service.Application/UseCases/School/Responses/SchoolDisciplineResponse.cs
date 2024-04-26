using MinhaEscola.Service.Application.UseCases.Component.Responses;
using MinhaEscola.Service.Application.UseCases.Discipline.Responses;
using MinhaEscola.Service.Domain.Board.School.ValueObject;

namespace MinhaEscola.Service.Application.UseCases.School.Responses
{
    public class SchoolDisciplineResponse
    {
        public long Id { get; set; }
        public long ComponentId { get; set; }
        public long DisciplineId { get; set; }
        public long SchoolId { get; set; }

        public ComponentResponse Component { get; set; }
        public DisciplineResponse Discipline { get; set; }

        public WorkLoad WorkLoad { get; set; }
    }
}
