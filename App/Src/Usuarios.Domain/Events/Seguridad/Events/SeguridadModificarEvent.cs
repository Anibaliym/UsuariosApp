using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Events.Seguridad.Events
{
    public class SeguridadModificarEvent : Event
    {
        public SeguridadModificarEvent(Guid id, Guid idUsuario, string contrasena, int intentos, DateTime fechaCreacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            Contrasena = contrasena;
            Intentos = intentos;
            FechaCreacion = fechaCreacion;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public int Intentos { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

}
