using Microsoft.AspNetCore.Authorization;
using MinhaEscola.Service.Application.UseCases.Base.Response;
using MinhaEscola.Service.Application.UseCases.KnowledgeArea.Interfaces;

namespace MinhaEscola.Service.Web.EndPoints.Knowledge
{
    [HttpGet("/knowledge-area/")]
    [Authorize]
    public class GetAllKnowledgeAreaEndPoint : EndpointWithoutRequest<ApiResponse>
    {
        private readonly IKnowledgeAreaQueries _queries;

        public GetAllKnowledgeAreaEndPoint(IKnowledgeAreaQueries queries) { 
            _queries= queries;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await _queries.GetAll());
        }
    }
}
