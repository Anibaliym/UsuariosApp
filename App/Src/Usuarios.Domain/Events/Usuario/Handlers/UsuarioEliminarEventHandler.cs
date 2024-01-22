using MediatR;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Events.Usuario.Handlers
{
    public partial class UsuarioEliminarEventHandler : INotificationHandler<UsuarioEliminarEvent>
    {
        public Task Handle(UsuarioEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
