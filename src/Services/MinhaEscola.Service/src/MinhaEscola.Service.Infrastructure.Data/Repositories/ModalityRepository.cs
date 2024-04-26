using MinhaEscola.Service.Domain.Administractive.Modality.Interfaces;
using MinhaEscola.Service.Domain.Administractive.Modality.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class ModalityRepository : BaseRepository<Modality>, IModalityRepository
    {
        public ModalityRepository(ApplicationContext context) : base(context) { }
    }
}
