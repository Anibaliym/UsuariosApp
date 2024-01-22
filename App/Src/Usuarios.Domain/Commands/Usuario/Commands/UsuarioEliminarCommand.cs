using Usuarios.Domain.Commands.Usuario.Validations;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Usuario.Commands
{
    public class UsuarioEliminarCommand : UsuarioCommand
    {
        public UsuarioEliminarCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
