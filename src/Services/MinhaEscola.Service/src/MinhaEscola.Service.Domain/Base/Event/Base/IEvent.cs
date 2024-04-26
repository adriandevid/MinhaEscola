
using MediatR;

namespace MinhaEscola.Service.Domain.Base.Event.Base
{
    public interface IEvent : INotification
    {
        public long Id { get; set; }
    }
}
