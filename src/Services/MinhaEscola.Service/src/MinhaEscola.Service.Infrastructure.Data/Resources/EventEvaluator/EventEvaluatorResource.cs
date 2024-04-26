using Marten;
using Marten.Exceptions;
using MediatR;
using MinhaEscola.Service.Domain.Base.Entitie;
using MinhaEscola.Service.Domain.Base.Event.Base;
using MinhaEscola.Service.Domain.Base.Interfaces;
using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces;
using MinhaEscola.Service.Infrastructure.Data.Context;

namespace MinhaEscola.Service.Infrastructure.Data.Resources.EventEvaluator
{
    public class EventEvaluatorResource : IEventEvaluatorResource
    {
        protected readonly ApplicationContext _context;
        protected readonly IMediator _mediator;
        private readonly IDocumentStore _documentStore;
        private readonly IWebSocketService _webSocket;

        public EventEvaluatorResource(ApplicationContext context, IMediator mediator, IDocumentStore documentStore, IWebSocketService webSocketService)
        {
            _context = context;
            _mediator = mediator;
            _documentStore = documentStore;
            _webSocket = webSocketService;
        }

        public async Task DispatchEvents()
        {
            try
            {
                var events = GetAllEventsOfContext();

                if (events.Count > 0)
                {
                    await using (var session = _documentStore.LightweightSession())
                    {
                        session.Events.StartStream(Guid.NewGuid(), events);

                        await session.SaveChangesAsync();
                    }

                    foreach (object @event in events)
                    {
                        await _mediator.Publish(@event);
                        //Todo: Sends request to websocket
                        //await _webSocket.SendMessage(new ModelSendMessageWebSocket() { 
                        //    Code = "Event-Dispath",
                        //    Description = "Sending event",
                        //    Data = @event
                        //});
                    }
                }
            }
            catch (Marten.Exceptions.InvalidDocumentException ex)
            {
                throw new InvalidDocumentException("Document is invalid!");

            }
            catch (Exception ex) {
                throw new Exception("Error in execution of procedure!");
            }
        }

        private List<IEvent> GetAllEventsOfContext() {
            var entities = _context.ChangeTracker.Entries<Entity>().Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();
            
            entities.ForEach(entry => entry.Entity.DomainEvents.ToList().ForEach(@event => @event.Id = entry.Entity.Id));

            return entities.SelectMany(x => x.Entity.DomainEvents).ToList();
        }
    }
}
