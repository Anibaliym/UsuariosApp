using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Events.Usuario.Events
{
    public class UsuarioCrearEvent : Event
    {
        public UsuarioCrearEvent(Guid id, Guid idPersona, string nick, string tipo, string estado)
        {
            Id = id;
            IdPersona = idPersona;
            Nick = nick;
            Tipo = tipo;
            Estado = estado;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Nick { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
