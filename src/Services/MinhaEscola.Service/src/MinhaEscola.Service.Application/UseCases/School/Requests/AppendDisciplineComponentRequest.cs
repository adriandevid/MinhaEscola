using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public class AppendDisciplineComponentRequest : IRequest<ApiResponse>
    {
        public long ComponentId { get; set; }
        public long DisciplineId { get; set; }
        public long SchoolId { get; set; }
        public long WeeklyClass { get; set; }
        public long AnnualClass { get; set; }
        public long WeekHours { get; set; }
    }
}
