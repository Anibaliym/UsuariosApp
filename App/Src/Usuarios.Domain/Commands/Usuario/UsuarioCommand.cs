using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Usuario
{
    public abstract class UsuarioCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Nick { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
