using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Domain.Base.Interfaces;

namespace MinhaEscola.Service.Infrastructure.Data.Resources.UnitOfWork
{
    public class UnitOfWorkResource : IUnitOfWorkResource, IDisposable
    {
        private readonly ApplicationContext _context;
        private readonly IEventEvaluatorResource _eventEvaluatorResource;

        public UnitOfWorkResource(ApplicationContext context, IEventEvaluatorResource eventEvaluatorResource)
        {
            _context = context;
            _eventEvaluatorResource = eventEvaluatorResource;

        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Save()
        {
            var resultOperation = await _context.SaveChangesAsync() > 0;

            if (resultOperation) {
                await _eventEvaluatorResource.DispatchEvents();
            }

            return resultOperation;
        }
    }
}
