using Usuarios.Domain.Commands.Usuario.Validations;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Usuario.Commands
{
    public class UsuarioModificarCommand : UsuarioCommand
    {
        public UsuarioModificarCommand(Guid id, Guid idPersona, string nick, string tipo, string estado)
        {
            Id = id;
            IdPersona = idPersona;
            Nick = nick;
            Tipo = tipo;
            Estado = estado;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
