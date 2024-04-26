using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Administractive.Stage.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Stage.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class StageRepository : BaseRepository<Stage>, IStageRepository
    {

        public StageRepository(ApplicationContext context) : base(context) { }

        public async Task<Stage> GetByIdWithAllIncludes(long id)
            => await _dbSet.Include(x => x.LevelEducation).FirstOrDefaultAsync(x => x.Id == id);
    }
}
