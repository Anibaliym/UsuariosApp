using System.ComponentModel;

namespace Usuarios.Application.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [DisplayName("Identificador")]
        public Guid Id{ get; set; }

        [DisplayName("Identificador Persona")]
        public Guid IdPersona { get; set; }

        [DisplayName("Nick")]
        public string Nick { get; set; } = string.Empty;

        [DisplayName("Tipo")]
        public string Tipo { get; set; } = string.Empty;

        [DisplayName("Estado")]
        public string Estado { get; set; } = string.Empty;
    }
}
