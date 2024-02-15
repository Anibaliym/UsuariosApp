using System.ComponentModel;

namespace Usuarios.Application.ViewModels.Seguridad
{
    public class SeguridadCrearViewModel
    {
        [DisplayName("Identificador Usuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Contraseña usuario")]
        public string Contrasena { get; set; } = string.Empty;
    }
}
