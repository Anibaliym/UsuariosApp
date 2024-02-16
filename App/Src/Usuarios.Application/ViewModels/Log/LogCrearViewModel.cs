using System.ComponentModel;

namespace Usuarios.Application.ViewModels.Log
{
    public class LogCrearViewModel
    {
        [DisplayName("Identificador Usuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Accion")]
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Observación")]
        public string Observacion { get; set; } = string.Empty;
    }
}
