using Usuarios.Domain.Commands.Usuario.Commands;

namespace Usuarios.Domain.Commands.Usuario.Validations
{
    public class UsuarioEliminarCommandValidations : UsuarioValidation<UsuarioEliminarCommand>
    {
        public UsuarioEliminarCommandValidations()
        {
            ValidaId(); 
        }
    }
}
