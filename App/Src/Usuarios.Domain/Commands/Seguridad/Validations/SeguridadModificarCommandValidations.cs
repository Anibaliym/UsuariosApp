using Usuarios.Domain.Commands.Seguridad.Commands;

namespace Usuarios.Domain.Commands.Seguridad.Validations
{
    public class SeguridadModificarCommandValidations : SeguridadValidation<SeguridadModificarCommand>
    {
        public SeguridadModificarCommandValidations()
        {
            ValidaId();
            ValidaIdUsuario();
            ValidaContrasena();
            ValidaIntentos();
        }
    }
}
