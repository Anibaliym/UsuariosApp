using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Log
{
    public abstract class LogCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
