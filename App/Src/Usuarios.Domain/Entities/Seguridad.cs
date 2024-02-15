using Usuarios.Domain.Core.Dominio;

namespace Usuarios.Domain.Entities
{
    public class Seguridad : Entity, IAggregateRoot
    {
        public Seguridad(Guid id, Guid idUsuario, string contrasena, int intentos, DateTime fechaCreacion)
        {
            Id = id;
            IdUsuario = idUsuario;
            Contrasena = contrasena;
            Intentos = intentos;
            FechaCreacion = fechaCreacion;
        }

        protected Seguridad() { }

        public Guid IdUsuario { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public int Intentos { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
