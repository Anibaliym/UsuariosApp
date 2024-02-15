using MediatR;
using Usuarios.Domain.Events.Seguridad.Events;

namespace Usuarios.Domain.Events.Seguridad.Handlers
{
    //SeguridadModificarEventHandler
    public partial class SeguridadModificarEventHandler : INotificationHandler<SeguridadModificarEvent>
    {
        public Task Handle(SeguridadModificarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
