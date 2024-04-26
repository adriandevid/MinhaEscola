using MediatR;
using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Requests
{
    public class UpdateKnowledgeAreaRequest : IRequest<ApiResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
