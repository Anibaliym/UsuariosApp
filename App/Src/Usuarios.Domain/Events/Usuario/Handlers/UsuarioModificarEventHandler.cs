using MediatR;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Events.Usuario.Handlers
{
    public partial class UsuarioModificarEventHandler : INotificationHandler<UsuarioModificarEvent>
    {
        public Task Handle(UsuarioModificarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
