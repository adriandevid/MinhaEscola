

using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.LevelEducation.Interfaces
{
    public interface ILevelEducationQueries
    {
        Task<ApiResponse> GetAll();
    }
}
