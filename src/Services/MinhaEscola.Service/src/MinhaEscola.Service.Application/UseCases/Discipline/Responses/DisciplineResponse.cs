using Microsoft.AspNetCore.Routing.Patterns;


namespace MinhaEscola.Service.Application.UseCases.Discipline.Responses
{
    public class DisciplineResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long KnowledgeAreaId { get; set; }
    }
}
