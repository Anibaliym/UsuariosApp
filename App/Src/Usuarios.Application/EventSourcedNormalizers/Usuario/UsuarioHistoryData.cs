using Usuarios.Domain.Core.Models;

namespace Usuarios.Application.EventSourcedNormalizers.Usuario
{
    public class UsuarioHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdPersona { get; set; } = string.Empty;
        public string Nick { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
