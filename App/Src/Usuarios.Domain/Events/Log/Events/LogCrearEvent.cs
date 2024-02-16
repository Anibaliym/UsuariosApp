using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Events.Log.Events
{
    public class LogCrearEvent : Event
    {
        public LogCrearEvent(Guid id, Guid idUsuario, string accion, string observacion, DateTime fechaCreacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            Accion = accion;
            Observacion = observacion;
            FechaCreacion = fechaCreacion;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Accion { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
