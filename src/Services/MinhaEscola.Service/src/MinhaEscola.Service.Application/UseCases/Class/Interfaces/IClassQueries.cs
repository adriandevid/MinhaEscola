using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.Class.Interfaces
{
    public interface IClassQueries
    {
        Task<ApiResponse> GetClassesOfSchoolByUserReference();
        Task<ApiResponse> GetById(long id);
    }
}
