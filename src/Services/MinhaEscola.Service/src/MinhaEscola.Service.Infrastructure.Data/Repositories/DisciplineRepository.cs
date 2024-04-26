using MinhaEscola.Service.Domain.Administractive.Discipline.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Discipline.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class DisciplineRepository : BaseRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
