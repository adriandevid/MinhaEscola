using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Stage.Interfaces
{
    public interface IStageQueries
    {
        Task<ApiResponse> GetAll();
    }
}
