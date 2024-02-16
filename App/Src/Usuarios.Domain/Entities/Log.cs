using Usuarios.Domain.Core.Dominio;

namespace Usuarios.Domain.Entities
{
    public class Log : Entity, IAggregateRoot
    {
        public Log(Guid id, Guid idUsuario, string accion, string observacion, DateTime fechaCreacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            Accion = accion;
            Observacion = observacion;
            FechaCreacion = fechaCreacion;
        }

        protected Log() { }

        public Guid IdUsuario { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
