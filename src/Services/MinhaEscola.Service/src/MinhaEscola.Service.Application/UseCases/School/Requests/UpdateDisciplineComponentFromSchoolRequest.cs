using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Requests
{
    public  class UpdateDisciplineComponentFromSchoolRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public long WeeklyClass { get; set; }
        public long AnnualClass { get; set; }
        public long WeekHours { get; set; }
    }
}
