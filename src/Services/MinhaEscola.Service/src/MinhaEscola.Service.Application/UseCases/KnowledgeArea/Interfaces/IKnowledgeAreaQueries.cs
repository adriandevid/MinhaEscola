using MinhaEscola.Service.Application.UseCases.Base.Response;


namespace MinhaEscola.Service.Application.UseCases.KnowledgeArea.Interfaces
{
    public interface IKnowledgeAreaQueries
    {
        Task<ApiResponse> GetAll();
    }
}
