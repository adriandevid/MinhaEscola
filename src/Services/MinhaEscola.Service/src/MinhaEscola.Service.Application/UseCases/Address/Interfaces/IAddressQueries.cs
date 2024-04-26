using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Address.Interfaces
{
    public interface IAddressQueries
    {
        Task<ApiResponse> GetById(long id);
    }
}
