using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Requests
{
    public class CreateDisciplineRequest : IRequest<ApiResponse>
    {
        public CreateDisciplineRequest()
        {

        }

        public string Name { get; set; }
        public long KnowledgeAreaId { get; set; }
    }
}
