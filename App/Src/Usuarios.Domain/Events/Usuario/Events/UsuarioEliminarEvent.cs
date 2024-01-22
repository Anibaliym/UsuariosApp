using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Events.Usuario.Events
{
    public class UsuarioEliminarEvent : Event
    {
        public UsuarioEliminarEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
