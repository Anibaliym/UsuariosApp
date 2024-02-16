using Usuarios.Domain.Core.Dominio;

namespace Usuarios.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario(Guid id, Guid idPersona, string nick, string tipo, string estado)
        {
            Id = id;
            IdPersona = idPersona;
            Nick = nick;
            Tipo = tipo;
            Estado = estado;
        }

        protected Usuario() { }

        public Guid IdPersona { get; set; }
        public string Nick { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
