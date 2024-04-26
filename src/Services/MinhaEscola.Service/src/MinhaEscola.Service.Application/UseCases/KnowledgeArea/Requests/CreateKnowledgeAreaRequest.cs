using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests
{
    public class CreateKnowledgeAreaRequest : IRequest<ApiResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
