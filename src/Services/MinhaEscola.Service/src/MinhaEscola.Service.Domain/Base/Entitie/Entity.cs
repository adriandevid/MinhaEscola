using MinhaEscola.Service.Domain.Base.Event.Base;

namespace MinhaEscola.Service.Domain.Base.Entitie
{
    public class Entity
    {
        public long Id { get; set; }

        private List<IEvent> _domainEvents = new List<IEvent>();
        public IReadOnlyList<IEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AppendEvent(IEvent notification)
        {
            _domainEvents.Add(notification);
        }

        protected void RemoveEvent(IEvent notification)
        {
            _domainEvents.Remove(notification);
        }

        protected void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
