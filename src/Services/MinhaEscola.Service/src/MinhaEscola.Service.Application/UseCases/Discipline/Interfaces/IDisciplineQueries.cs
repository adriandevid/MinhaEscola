

using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Discipline.Interfaces
{
    public interface IDisciplineQueries
    {
        Task<ApiResponse> GetAll();
    }
}
