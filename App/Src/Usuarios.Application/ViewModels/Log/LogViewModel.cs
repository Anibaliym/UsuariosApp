using System.ComponentModel;

namespace Usuarios.Application.ViewModels.Log
{
    public class LogViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Identificador Usuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Accion")]
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Observación")]
        public string Observacion { get; set; } = string.Empty;

        [DisplayName("Fecha Creación")]
        public DateTime FechaCreacion { get; set; }
    }
}
