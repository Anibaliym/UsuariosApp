using MediatR;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Events.Usuario.Handlers
{
    public partial class UsuarioCrearEventHandler : INotificationHandler<UsuarioCrearEvent>
    {
        public Task Handle(UsuarioCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
