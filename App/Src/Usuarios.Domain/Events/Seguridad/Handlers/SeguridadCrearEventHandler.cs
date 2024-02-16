using MediatR;
using Usuarios.Domain.Events.Seguridad.Events;

namespace Usuarios.Domain.Events.Seguridad.Handlers
{
    public partial class SeguridadCrearEventHandler : INotificationHandler<SeguridadCrearEvent>
    {
        public Task Handle(SeguridadCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
