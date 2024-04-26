using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Modality.Interfaces
{
    public interface IModalityQueries
    {
        Task<ApiResponse> GetAll();
    }
}
