using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Component.Interfaces
{
    public interface IComponentQueries
    {
        Task<ApiResponse> GetAllDenominations();
        Task<ApiResponse> GetAll();
    }
}
