namespace MinhaEscola.Service.Domain.Base.Interfaces
{
    public interface IUnitOfWorkResource
    {
        Task<bool> Save();
    }
}
