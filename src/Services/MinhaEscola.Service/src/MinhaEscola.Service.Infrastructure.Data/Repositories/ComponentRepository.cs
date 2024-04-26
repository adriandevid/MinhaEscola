using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Administractive.Component.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class ComponentRepository : BaseRepository<Component>, IComponentRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ComponentRepository(ApplicationContext context) : base(context)
        {
            _applicationContext = context;
        }

        public async Task<List<Denomination>> GetAllDenominations()
            => await _applicationContext.Set<Denomination>().ToListAsync();

        public async Task<Denomination> GetDenominationById(long denominationId)
            => await _applicationContext.Set<Denomination>().FirstOrDefaultAsync(x => x.Id == denominationId);
    }
}
