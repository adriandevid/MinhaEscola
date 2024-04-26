using MinhaEscola.Service.Domain.Administractive.LevelEducation.Interfaces;
using MinhaEscola.Service.Domain.Administractive.LevelEducation.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class LevelEducationRepository : BaseRepository<LevelEducation>, ILevelEducationRepository
    {
        public LevelEducationRepository(ApplicationContext context) : base(context) { }
    }
}
