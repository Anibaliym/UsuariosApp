using System.ComponentModel;

namespace Usuarios.Application.ViewModels.Seguridad
{
    public class SeguridadModificarViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [DisplayName("Identificador Usuario")]
        public Guid IdUsuario { get; set; }

        [DisplayName("Contraseña usuario")]
        public string Contrasena { get; set; } = string.Empty;

        [DisplayName("Intentos fallidos")]
        public int Intentos { get; set; }
    }
}
