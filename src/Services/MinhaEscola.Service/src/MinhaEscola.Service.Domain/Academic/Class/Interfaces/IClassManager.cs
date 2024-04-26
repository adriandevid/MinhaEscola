namespace MinhaEscola.Service.Domain.Academic.Class.Interfaces
{
    public interface IClassManager
    {
        Task Create(long schoolId, Class.Limits.Class @class);
        Task Update(long schoolId, Class.Limits.Class @class);
    }
}
