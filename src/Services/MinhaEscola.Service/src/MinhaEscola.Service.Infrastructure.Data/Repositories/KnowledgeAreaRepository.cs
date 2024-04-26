using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Interfaces;
using MinhaEscola.Service.Domain.Administractive.KnowledgeArea.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class KnowledgeAreaRepository : BaseRepository<KnowledgeArea>, IKnowledgeAreaRepository
    {
        public KnowledgeAreaRepository(ApplicationContext context) : base(context) { }
    }
}
