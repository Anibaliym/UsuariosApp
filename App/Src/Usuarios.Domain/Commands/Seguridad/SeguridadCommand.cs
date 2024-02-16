using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Seguridad
{
    public abstract class SeguridadCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public int Intentos { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
