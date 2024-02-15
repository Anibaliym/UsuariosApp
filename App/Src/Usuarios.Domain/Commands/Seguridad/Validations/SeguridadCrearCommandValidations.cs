using Usuarios.Domain.Commands.Seguridad.Commands;

namespace Usuarios.Domain.Commands.Seguridad.Validations
{
    public class SeguridadCrearCommandValidations : SeguridadValidation<SeguridadCrearCommand>
    {
        public SeguridadCrearCommandValidations()
        {
            ValidaIdUsuario(); 
            ValidaContrasena();
        }
    }
}
