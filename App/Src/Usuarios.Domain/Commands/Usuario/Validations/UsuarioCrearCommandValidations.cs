using Usuarios.Domain.Commands.Usuario.Commands;

namespace Usuarios.Domain.Commands.Usuario.Validations
{
    public class UsuarioCrearCommandValidations : UsuarioValidation<UsuarioCrearCommand>
    {
        public UsuarioCrearCommandValidations()
        {
            ValidaIdPersona();
            ValidaNick(); 
            ValidaTipo();
            ValidaEstado();
        }
    }
}
