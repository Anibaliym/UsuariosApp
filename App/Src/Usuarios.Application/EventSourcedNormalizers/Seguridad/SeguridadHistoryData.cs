using Usuarios.Domain.Core.Models;

namespace Usuarios.Application.EventSourcedNormalizers.Seguridad
{
    public class SeguridadHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Intentos { get; set; } = string.Empty;
        public string FechaCreacion { get; set; } = string.Empty;
    }
}
