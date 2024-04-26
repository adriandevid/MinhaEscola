using MinhaEscola.Service.Application.UseCases.Base.Response;

namespace MinhaEscola.Service.Application.UseCases.School.Interfaces
{
    public interface ISchoolQueries
    {
        Task<ApiResponse> GetComponentsOfSchoolById(long schoolId);
        Task<ApiResponse> GetSchoolById(long id);
        Task<ApiResponse> GetAll();
        Task<ApiResponse> GetByUserReference();
        Task<ApiResponse> GetComponentsOfSchoolByUserReference();
        Task<ApiResponse> GetDisciplinesOfSchoolById(long schoolId);
        Task<ApiResponse> GetDisciplineComponent(long schoolId, long id);
    }
}
