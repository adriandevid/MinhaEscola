using MediatR;
using MinhaEscola.Service.Domain.Board.School.Events;

namespace MinhaEscola.Service.Application.UseCases.School.Events
{
    public class SchoolCreatedEventHandler : INotificationHandler<SchoolCreatedDomainEvent>
    {
        public async Task Handle(SchoolCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => { Console.WriteLine("Acionado"); });
        }
    }
}
