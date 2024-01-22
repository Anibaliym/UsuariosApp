using Usuarios.Domain.Commands.Usuario.Commands;

namespace Usuarios.Domain.Commands.Usuario.Validations
{
    public class UsuarioModificarCommandValidations : UsuarioValidation<UsuarioModificarCommand>
    {
        public UsuarioModificarCommandValidations()
        {
            ValidaId();
            ValidaIdPersona();
            ValidaNick(); 
            ValidaTipo();
            ValidaEstado();
        }
    }
}
