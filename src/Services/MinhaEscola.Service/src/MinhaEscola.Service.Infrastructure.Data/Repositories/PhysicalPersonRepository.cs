using MinhaEscola.Service.Domain.Core.PhysicalPerson.Interfaces;
using MinhaEscola.Service.Domain.Core.PhysicalPerson.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class PhysicalPersonRepository : BaseRepository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
