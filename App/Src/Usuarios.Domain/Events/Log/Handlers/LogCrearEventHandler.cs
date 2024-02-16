using MediatR;
using Usuarios.Domain.Events.Log.Events;

namespace Usuarios.Domain.Events.Log.Handlers
{
    public partial class LogCrearEventHandler : INotificationHandler<LogCrearEvent>
    {
        public Task Handle(LogCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
